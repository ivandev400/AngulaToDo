export interface Task {
  id?: number;
  title?: string;
  description?: string;
  isImportant?: boolean;
  completed?: boolean;
  created?: Date;
  dueDate?: Date;
}
