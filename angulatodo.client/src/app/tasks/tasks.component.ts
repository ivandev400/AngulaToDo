import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../services/task.service'; 

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})
export class TasksComponent implements OnInit {
  tasks: any[] = [];
  userId: string = '';

  constructor(private taskService: TaskService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.userId = this.route.snapshot.paramMap.get('userId')!;

    this.taskService.getAllTasks(this.userId).subscribe(tasks => {
      this.tasks = tasks;
    });
  }
  deleteTask(taskId: string) { }
}
