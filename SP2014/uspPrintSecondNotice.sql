USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspPrintSecondNotice]    Script Date: 02/10/2015 12:11:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- 02/09/2015  _obd
CREATE PROCEDURE [dbo].[uspPrintSecondNotice]
--@FromNoticeDate smalldatetime,
--@ToNoticeDate smalldatetime
@MediationCaseInformationID int
  
AS
SELECT     dbo.MortgagorInformation.MortgagorInformationID, dbo.MediationCaseInformation.MediationCaseInformationID, ISNULL(UPPER(dbo.MortgagorInformation.FirstName), '') 
                      + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.MiddleInitial), '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.LastName), '') 
                      + ISNULL(', ' + NULLIF (dbo.MortgagorInformation.Suffix, ''), '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.Alias), '') AS Name, dbo.MortgagorInformation.Alias,
                      ISNULL(UPPER(dbo.MortgagorInformation.Co_FirstName), '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.Co_MiddleInitial), '') 
                      + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.Co_LastName), '') + ISNULL(', ' + NULLIF (dbo.MortgagorInformation.Co_Suffix, ''), '') 
                      + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.Co_Alias), '') AS CoFullName, UPPER(dbo.MortgagorInformation.Address_1) AS Address, 
                      UPPER(dbo.MortgagorInformation.Address_2) AS Address_2, ISNULL(UPPER(dbo.MortgagorInformation.City) + ', ', '') 
                      + ISNULL(UPPER(dbo.MortgagorInformation.State) + ' ', '') + ISNULL(dbo.MortgagorInformation.ZipCode, '') AS CityStateZip, 
                      UPPER(dbo.MortgagorInformation.Address_1) 
                      + (CASE WHEN MortgagorInformation.Address_2 > '' THEN ', ' + UPPER(MortgagorInformation.Address_2 + ', ') ELSE ', ' END) 
                      + UPPER(dbo.MortgagorInformation.City) + ', ' + UPPER(dbo.MortgagorInformation.State) + ' ' + UPPER(dbo.MortgagorInformation.ZipCode) 
                      AS AddressCityStateZip, dbo.MediationCaseInformation.FirstLetterSentDate, dbo.MediationCaseInformation.CreateDate,dbo.MediationCaseInformation.NoticeDate
FROM         dbo.MortgagorInformation INNER JOIN
                      dbo.MediationCaseInformation ON dbo.MortgagorInformation.MortgagorInformationID = dbo.MediationCaseInformation.MortgagorInformationID
WHERE     (dbo.MediationCaseInformation.SecondLetterSentDate IS NULL) AND (DATEDIFF(DAY, dbo.MediationCaseInformation.FirstLetterSentDate, GETDATE()) 
                      > 2)
ORDER BY MediationCaseInformation.MediationCaseInformationID ASC
RETURN
GO

