# memory-overflow

The goal of this repository is to test out different patterns found in https://www.amazon.com/Fundamentals-Software-Architecture-Comprehensive-Characteristics/dp/1492043451. The goal is to write a very primative version of stackoverflow and use the different patterns as an exploration excercise.

Scope of the UI:
- users can create posts/questions
    - users can upvote/downvote
    - create comments
- users can create answers
    - upvote/downvote
    - create comments



# Datamodel:

*Notes*: While post and answer may look the same in this data model. I wanted to seperate them in the database as they are conceptually different things. This does cause some duplication for comments but I'm ok with that duplication for now as again while they do sound very similar they technically are different. 1 is commenting on a post and the other is commenting on a Answer. By consolidating them into a single object I'd have quite some confusion on null columns. I may change this later but for now this is what I'm gonna stick with.

## Post
| Name      | Type | Description |
| ----------- | ----------- | ----------- |
| Id      | PK identity guid | Id of the post |
| Title | nvarchar(255) | Title of the question |
| Question | nvarchar(max) | Question Text |
| Vote Count | int default(0) | Number of "upvotes" can be negative |
| Created date | Datetime(2) default(now) | Time the post was created in UTC |
| UserId | Guid FK user | Id of the user that created this post |

## Answer
| Name      | Type | Description |
| ----------- | ----------- | ----------- |
| Id      | PK identity guid | Id of the Answer |
| Post Id      |  guid FK Post | Id of post this is answering |
| Text | nvarchar(max) | Question Text |
| Vote Count | int default(0) | Number of "upvotes" can be negative |
| Created date | Datetime(2) default(now) | Time the post was created in UTC |
| UserId | Guid FK user | Id of the user that created this answer |

## Post Comment
| Name      | Type | Description |
| ----------- | ----------- | ----------- |
| Id | PK identity guid | Id of the Answer |
| Post Id |  guid FK Post | Id of post this is commenting on |
| Text | nvarchar(max) | Comment text |
| Created date | Datetime(2) default(now) | Time the post was created in UTC |
| UserId | Guid FK user | Id of the user that created this comment |

## Answer Comment
| Name      | Type | Description |
| ----------- | ----------- | ----------- |
| Id | PK identity guid | Id of the Answer |
| Answer Id |  guid FK Answer | Id of answer this is commenting on |
| Text | nvarchar(max) | Comment text |
| Created date | Datetime(2) default(now) | Time the post was created in UTC |
| UserId | Guid FK user | Id of the user that created this comment |


## User
| Name      | Type | Description |
| ----------- | ----------- | ----------- |
| Id | PK identity guid | Id of the User |
| Name | narchar(200) | username of the user |
| Created date | Datetime(2) default(now) | Time the user was created in UTC |


# API
This section is dedicated to the API of this system and outlines what will be supported and how. Ultimatly this would be converted into a swagger document but for the purposes of planning this is what's required. The API should be quite simple
- CRUD on posts
- CD on answers
- CD on post comments
- CD on answer comments

Where 
- C == Create
- R == Read
- U == Update
- D == Delete

for now I don't want to support update as there is some overhead and this project is meant to be a fun exploration of architecture not having a complete

# Posts

## **Get All Posts**
**Get:** `/api/post`

*Description*: Returns a slimed down version of all the posts, ordered by created date, most recently created item will be at the top.

**Returns:**
```
[
    {
        id: guid/ string,
        title: string,
        text: string,
        owner: User
    }
]
```
---
## **Get Post**

**Get:** `/api/post/{id:guid}`

*Description*: Returns the full post definition used to render a detailed page of the post, answers and comments.

**Returns:**
```
{
    id: guid/string,
    title: string,
    text: string,
    owner: User,
    answers: Answer[],
    comments: Comment[]
}

```
---
## **Create Post**

**Post:** `/api/post`

*Description*: Creates a new Post in the system. Note while owner is required in the database the API should be incharge of determining that not the api body.

**Body:**
```
{
    title: string,
    text: string,
}

```
**Returns:**
```
{
    id: guid/string,
    title: string,
    text: string,
}

```
---
## **Update Post**

**Patch:** `/api/post/{id:guid}`

*Description*: Changes the post's title or text, note both items will be required as the API is naive and will just write w/e is in this object to the database.

**Body:**
```
{
    id: guid/string,
    title: string,
    text: string,
}

```

**Returns:**
```
{
    id: guid/string,
    title: string,
    text: string,
}

```
---
## **Delete Post**

**Delete:** `/api/post/{id:guid}`

*Description*: Deletes the post and all the answers and comments downstream

---
## **Create Comment**

**Post:** `/api/post/{id:guid}/comment`

*Description*: Creates a new comment of the post. Note while owner is required in the database the API should be incharge of determining that not the api body.

**Body:**
```
{
    message: string,
}

```
**Returns:**
```
{
    id: guid/string,
    message: string,
    user: User
}

```
---
## **Delete Post Comment**

**Post:** `/api/post/{id:guid}/comment/{id:guid}`

*Description*: Delete's a comment on the post

**Returns:**
201 Accepted

## **Vote On Post**

**Post:** `/api/post/{id:guid}/vote`

*Description*: Changes the vote on the post

**Body:**
```
{
    vote: number, // < 0 means 1 downvote >0 means upvote, passing 5 for instance means it was upvoted so 1 is added to the vote count not 5
}

```
**Returns:**
201 Accepted


# Answers
## **Create Answer**

**Post:** `/api/post/{id:guid}/answer`

*Description*: Creates a new answer on the post

**Body:**
```
{
    message: string
}
```

**Returns:**
```
{
    id: guid/string,
    message: string
}

```
---
## **Delete Answer**

**Delete:** `/api/post/{id:guid}/answer/{id:guid}`

*Description*: Deletes and answer

**Returns:**
201 Accepted

---
## **Create Answer comment**

**Post:** `/api/post/{id:guid}/answer/{id:guid}/comment`

*Description*: Creates a new comment of the answer. Note while owner is required in the database the API should be incharge of determining that not the api body.

**Body:**
```
{
    message: string,
}

```
**Returns:**
```
{
    id: guid/string,
    message: string,
    user: User
}

```

---
## **Delete Answer comment**

**Post:** `/api/post/{id:guid}/answer/{id:guid}/comment/{id:guid}`

*Description*: Deletes a comment on that answer.

**Returns:**
201 Accepted

---

## **Vote on answer**

**Post:** `/api/post/{id:guid}/answer/{id:guid}/vote`

*Description*: Votes on that answer.

**Body:**
```
{
    vote: number, // < 0 means 1 downvote >0 means upvote, passing 5 for instance means it was upvoted so 1 is added to the vote count not 5
}

```
**Returns:**
201 Accepted
