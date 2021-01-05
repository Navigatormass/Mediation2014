USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspPrintSecondLetter]    Script Date: 02/10/2015 12:11:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspPrintSecondLetter]
--@FromNoticeDate smalldatetime,
--@ToNoticeDate smalldatetime
@MediationCaseInformationID int
    /*
    (
    @parameter1 int = 5,
    @parameter2 datatype OUTPUT
    )
    */
AS
SELECT     dbo.MediationCaseInformation.MediationCaseInformationID, dbo.MortgagorInformation.MortgagorInformationID, ISNULL(UPPER(dbo.MortgagorInformation.FirstName), '') 
                      + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.MiddleInitial), '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.LastName), '') AS Name, 
                      ISNULL(UPPER(dbo.MortgagorInformation.Co_FirstName), '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.Co_MiddleInitial), '') 
                      + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.Co_LastName), '') AS CoFullName, UPPER(dbo.MortgagorInformation.Address_1) AS Address, 
                      UPPER(dbo.MortgagorInformation.Address_2) AS Address_2, ISNULL(UPPER(dbo.MortgagorInformation.City) + ', ', '') + ISNULL(UPPER(dbo.MortgagorInformation.State)
                       + ' ', '') + ISNULL(dbo.MortgagorInformation.ZipCode, '') AS CityStateZip, UPPER(dbo.MortgagorInformation.Address_1) 
                      + (CASE WHEN MortgagorInformation.Address_2 > '' THEN ', ' + UPPER(MortgagorInformation.Address_2 + ', ') ELSE ', ' END) + UPPER(dbo.MortgagorInformation.City) 
                      + ', ' + UPPER(dbo.MortgagorInformation.State) + ' ' + UPPER(dbo.MortgagorInformation.ZipCode) AS AddressCityStateZip, 
                      dbo.MediationCaseInformation.MediationCaseInformationID, dbo.MediationCaseInformation.FirstLetterSentDate,dbo.MediationCaseInformation.CreateDate,dbo.MediationCaseInformation.NoticeDate
FROM         dbo.MortgagorInformation INNER JOIN
                      dbo.MediationCaseInformation ON dbo.MortgagorInformation.MortgagorInformationID = dbo.MediationCaseInformation.MortgagorInformationID
WHERE
		(MediationCaseInformation.SecondLetterSentDate IS NULL) AND
        (DATEDIFF(DAY, MediationCaseInformation.FirstLetterSentDate, GETDATE()) > 2) ORDER BY MediationCaseInformation.MediationCaseInformationID ASC
           /* SET NOCOUNT ON */
    RETURN
GO

