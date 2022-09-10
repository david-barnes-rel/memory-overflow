import { Answer } from "./answer.model";
import { Comment } from "./comment.model";
import { PostSlim } from "./post-slim.model";

export interface PostDetail extends PostSlim {
  answers: Answer[],
  comments: Comment[]
}
