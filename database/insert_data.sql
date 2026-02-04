-- Sample Data

INSERT INTO Users (Username, Email) VALUES
('Neha', 'neha@gmail.com'),
('Amit', 'amit@gmail.com');

INSERT INTO Categories (CategoryName) VALUES
('Technology'),
('Education');

INSERT INTO Posts (Title, Content, UserID, CategoryID) VALUES
('SQL Basics', 'Learn SQL step by step', 1, 2),
('Python Intro', 'Python for beginners', 2, 1);

INSERT INTO Comments (CommentText, PostID, UserID) VALUES
('Very helpful post!', 1, 2),
('Nice explanation', 2, 1);
