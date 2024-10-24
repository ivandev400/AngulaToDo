import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../services/task.service';
import { Task } from '../models/task';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';
import { getLocaleDateTimeFormat } from '@angular/common';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})
export class TasksComponent implements OnInit {
  tasks: Task[] = [];
  categories: any[] = [];
  userId: string = '';
  categoryId?: number = undefined;
  newTaskTitle: string = '';
  newTaskDueDate: Date = new Date();
  newTaskImportant: boolean = false;
  newCategoryName: string = '';

  constructor(private taskService: TaskService, private categoryService: CategoryService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.userId = this.route.snapshot.paramMap.get('userId')!;
    this.loadTasks();
    this.loadCategories();
  }

  addCategory() {
    if (!this.newCategoryName) {
      alert("Task title cannot be empty!");
      return;
    }

    this.categoryService.getCategoryByName(this.userId, this.newCategoryName)
      .pipe(
        catchError(error => {
          if (error.status === 404) {

            const newCategory: Category = { name: this.newCategoryName };

            return this.categoryService.createCategory(this.userId, newCategory);
          } else {
            return of(null);
          }
        })
      )
      .subscribe(existingOrNewCategory => {
        this.categoryId = existingOrNewCategory.id;
        this.addTask();
      });
  }
  
  addTask() {
    if (!this.newTaskTitle) {
      alert("Task title cannot be empty!");
      return;
    }

    const newTask: Task = {

      title: this.newTaskTitle,
      dueDate: this.newTaskDueDate,
      created: new Date(),
      isImportant: this.newTaskImportant,
      completed: false,
      categoryId: this.categoryId
    };

    this.taskService.createTask(this.userId, newTask);

    this.loadTasks();
    this.loadCategories();
    this.resetForm();
  }

  resetForm() {
    this.newTaskTitle = '';
    this.newTaskDueDate = new Date();
    this.newTaskImportant = false;
    this.categoryId = undefined;
    this.newCategoryName = '';
  }

  loadTasks() {
    this.taskService.getAllTasks(this.userId).subscribe(tasks => {
      this.tasks = tasks;
    });
  }

  loadCategories() {
    this.categoryService.getAllCategories(this.userId).subscribe(categories => {
      this.categories = categories;
    });
  }

  deleteTask(taskId?: number) {
    this.taskService.deleteTask(this.userId, taskId).subscribe(() => {
      this.loadTasks();
    });
  }

  updateTask(taskId?: number, task?: Task) {
    this.taskService.updateTask(this.userId, taskId, task).subscribe(() => {
      this.loadTasks();
    })
  }

  toggleImportance(task: Task) {
    task.isImportant = !task.isImportant;
    this.updateTask(task.id, task);
  }

  toggleCompleted(task: Task) {
    task.completed = !task.completed;
    this.updateTask(task.id, task);
  }
}
