export interface Task {
  id?: number;
  title?: string;
  description?: string;
  important?: boolean;
  completed?: boolean;
  created?: Date;
  dueDate?: Date;
  categoryId?: number;
}
