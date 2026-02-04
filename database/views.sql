CREATE VIEW vw_PostDetails AS
SELECT 
    P.Title,
    U.Username,
    C.CategoryName,
    P.CreatedAt
FROM Posts P
JOIN Users U ON P.UserID = U.UserID
JOIN Categories C ON P.CategoryID = C.CategoryID;
