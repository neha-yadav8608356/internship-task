-- Posts with User and Category
SELECT P.Title, U.Username, C.CategoryName
FROM Posts P
JOIN Users U ON P.UserID = U.UserID
JOIN Categories C ON P.CategoryID = C.CategoryID;

-- Total comments per post
SELECT P.Title, COUNT(C.CommentID) AS TotalComments
FROM Posts P
LEFT JOIN Comments C ON P.PostID = C.PostID
GROUP BY P.Title;

-- Total posts per user
SELECT U.Username, COUNT(P.PostID) AS TotalPosts
FROM Users U
LEFT JOIN Posts P ON U.UserID = U.UserID
GROUP BY U.Username;
