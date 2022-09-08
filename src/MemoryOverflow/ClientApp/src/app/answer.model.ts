import { Comment } from './comment.model';
export interface Answer {
  text: string;
  comments: Comment[]
}
