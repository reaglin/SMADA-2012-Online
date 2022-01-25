USE SMADA
GO

CREATE TABLE Feedback (
 id INT PRIMARY KEY IDENTITY(1,1),
 PageName VARCHAR(255),
 FeedbackText VARCHAR(MAX),
 IsResolved BIT, 
 EnteredByUserID INT,
 EnteredDate DATETIME )
GO

CREATE PROCEDURE sp_InsertFeedback (
 @PageName VARCHAR(255),
 @FeedbackText VARCHAR(MAX),
 @EnteredByUserID INT )
 AS
 BEGIN

INSERT INTO Feedback
 (PageName, FeedbackText, EnteredByUserID, EnteredDate)
 VALUES
 (@PageName, @FeedbackText, @EnteredByUserID, GETDATE())
 
 END
GO
 
CREATE VIEW view_Feedback
AS
SELECT 
 id,
 PageName,
 FeedbackText,
 IsResolved, 
 UserFullName,
 EnteredDate
FROM
 Feedback, UserLogin
WHERE 
 Feedback.EnteredByUserID = UserLogin.UserID  