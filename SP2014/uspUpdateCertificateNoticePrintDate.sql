USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateCertificateNoticePrintDate]    Script Date: 02/10/2015 12:15:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jaheda Meman>
-- Create date: 01/00/2015
-- Description:	Updates the SecondLetterSentDate column with current date
--              This procedure will excute after the Letters Have been printed 
-- =============================================
CREATE PROCEDURE [dbo].[uspUpdateCertificateNoticePrintDate]
	-- Add the parameters for the stored procedure here
	--@RecordsAffected int Output
 
   @MediationCaseIdList nvarchar(2000) 
 

  
AS

BEGIN



Create table #tempArrayTable (rid varchar(500))
Insert into #tempArrayTable (rid)
(select value from Split(@MediationCaseIdList,','))

DECLARE @ArrayItem nvarchar(100)
DECLARE @Array_Cursor CURSOR
SET @Array_Cursor = CURSOR FAST_FORWARD FOR select rid 
from #tempArrayTable

OPEN @Array_Cursor

FETCH NEXT FROM @Array_Cursor  INTO @ArrayItem


WHILE @@FETCH_STATUS = 0  
BEGIN

update MediationCaseInformation SET CertificateNoticePrintDate=GETDATE(),
 CertificateNoticeID = 1   

Where 

 MediationCaseInformationID=@ArrayItem


FETCH NEXT FROM @Array_Cursor INTO @ArrayItem

END

Close  @Array_Cursor
deallocate  @Array_Cursor

END

GO

