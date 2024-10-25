import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../services/task.service';
import { Task } from '../models/task';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';
import { getLocaleDateTimeFormat } from '@angular/common';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { FilterService } from '../services/filter.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})
export class TasksComponent implements OnInit {
  tasks: Task[] = [];
  categories: Category[] = [];
  userId: string = '';
  categoryId?: number = undefined;
  newTaskTitle: string = '';
  newTaskDueDate: string = '';
  newCategoryName: string = '';
  isDropDownOpen: boolean = false;

  paginatedTasks: Task[] = [];
  currentPage: number = 1;
  pageSize: number = 5;
  totalTasks: number = 0;

  constructor(private taskService: TaskService,
    private categoryService: CategoryService,
    private filterService: FilterService, private route: ActivatedRoute,
    private datePipe: DatePipe) { }

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
      .subscribe(category => {
        if (category != null) {
          this.categoryId = category.id;
          this.addTask();
        }
      });
  }
  
  addTask() {
    if (!this.newTaskTitle) {
      alert("Task title cannot be empty!");
      return;
    }

    const newTask: Task = {

      title: this.newTaskTitle,
      dueDate: new Date(this.newTaskDueDate),
      created: new Date(),
      isImportant: undefined,
      completed: false,
      categoryId: this.categoryId
    };

    this.taskService.createTask(this.userId, newTask).subscribe(() => {
      this.loadTasks();
      this.loadCategories();
      this.resetForm();
    });
  }

  resetForm() {
    this.newTaskTitle = '';
    this.newTaskDueDate = '';
    this.categoryId = undefined;
    this.newCategoryName = '';
  }

  formatDueDate(dueDate?: Date): string {
    return dueDate ? this.datePipe.transform(dueDate, 'yyyy-MM-dd') || '' : '';
  }

  setFormattedDueDate(task: Task, formattedDate: string) {
    task.dueDate = new Date(formattedDate); 
  }

  updatePaginatedTasks(): void {
    const start = (this.currentPage - 1) * this.pageSize;
    const end = start + this.pageSize;
    this.paginatedTasks = this.tasks.slice(start, end);
  }

  nextPage(): void {
    if (this.currentPage * this.pageSize < this.totalTasks) {
      this.currentPage++;
      this.updatePaginatedTasks();
    }
  }

  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.updatePaginatedTasks();
    }
  }

  loadTasksByCategory(categoryName?: string) {
    this.taskService.getTasksByCategoryName(this.userId, categoryName).subscribe(tasks => {
      this.tasks = tasks;
      this.totalTasks = tasks.length;
      this.updatePaginatedTasks();
    })
  }

  loadTasks() {
    this.taskService.getAllTasks(this.userId).subscribe(tasks => {
      this.tasks = tasks;
      this.totalTasks = tasks.length;
      this.updatePaginatedTasks();
    });
  }

  loadDailyTasks() {
    this.filterService.getDailyTasks(this.userId).subscribe(tasks => {
      this.tasks = tasks;
      this.totalTasks = tasks.length;
      this.updatePaginatedTasks();
    });
  }

  loadImportantTasks() {
    this.filterService.getImportantTasks(this.userId).subscribe(tasks => {
      this.tasks = tasks;
      this.totalTasks = tasks.length;
      this.updatePaginatedTasks();
    });
  }

  loadPlannedTasks() {
    this.filterService.getPlannedTasks(this.userId).subscribe(tasks => {
      this.tasks = tasks;
      this.totalTasks = tasks.length;
      this.updatePaginatedTasks();
    });
  }

  loadCompletedTasks() {
    this.filterService.getCompletedTasks(this.userId).subscribe(tasks => {
      this.tasks = tasks;
      this.totalTasks = tasks.length;
      this.updatePaginatedTasks();
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

  deleteCategory(categoryId?: number) {
    this.categoryService.deleteCategory(this.userId, categoryId).subscribe(() => {
      this.loadCategories();
    })
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

  toggleDropdown() {
    this.isDropDownOpen = !this.isDropDownOpen;
  }
}
