import { Comment } from './comment.model';
export interface Answer {
  id: string;
  text: string;
  comments: Comment[]
}
