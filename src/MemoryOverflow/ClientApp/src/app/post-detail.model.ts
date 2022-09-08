import { Answer } from "./answer.model";
import { PostSlim } from "./post-slim.model";

export interface PostDetail extends PostSlim {
   answers: Answer[]
}
