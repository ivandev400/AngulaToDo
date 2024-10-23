import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../services/task.service';
import { Task } from '../models/task';
import { getLocaleDateTimeFormat } from '@angular/common';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})
export class TasksComponent implements OnInit {
  tasks: any[] = [];
  userId: string = '';
  newTaskTitle: string = '';
  newTaskDueDate: Date = new Date();
  newTaskImportant: boolean = false;

  constructor(private taskService: TaskService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.userId = this.route.snapshot.paramMap.get('userId')!;
    this.loadTasks();
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
      important: this.newTaskImportant,
      completed: false,
      categoryId: undefined
    };

    this.taskService.createTask(this.userId, newTask).subscribe(() => {
      this.loadTasks();
    });

    this.newTaskTitle = '';
    this.newTaskDueDate = new Date();
    this.newTaskImportant = false;
  }

  loadTasks() {
    this.taskService.getAllTasks(this.userId).subscribe(tasks => {
      this.tasks = tasks;
    });
  }

  deleteTask(taskId: number) {
    this.taskService.deleteTask(this.userId, taskId).subscribe(() => {
      this.loadTasks();
    })
  }

  toggleImportance(task: Task) {
    task.important = !task.important;
  }

  toggleCompleted(task: Task) {
    task.completed = !task.completed;
  }
}
