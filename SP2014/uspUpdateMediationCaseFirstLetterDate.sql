USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateMediationCaseFirstLetterDate]    Script Date: 02/10/2015 12:16:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspUpdateMediationCaseFirstLetterDate]
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

update MediationCaseInformation set FirstLetterSentDate=GETDATE() where MediationCaseInformationID=@ArrayItem


FETCH NEXT FROM @Array_Cursor INTO @ArrayItem

END

Close  @Array_Cursor
deallocate  @Array_Cursor

END



GO

