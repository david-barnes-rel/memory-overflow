export interface User {
  id: string;
  name: string;
}
export interface Comment {
  id?: string;
  message: string;
  user?: User;
}
