USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspAddMediationNotes]    Script Date: 02/10/2015 12:03:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	<Author,,Jaheda Meman>
-- Create date: <01/14/14,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspAddMediationNotes] 
    -- Add the parameters for the stored procedure here
    --First two parameters we add for the edit add mortgagor using grid. When you go serach , click edit int the grid , it brings you on Add mortgagor page then we can save the record .
    
    @MediationCaseInformationID int,
    @Notes varchar(300)
  -- @UserID varchar(20),
  --  @TimeStamp smalldatetime,
   -- @Edit int,
   -- @outputNotesID int OUTPUT
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements. 
   -- SET NOCOUNT ON;
    --- This is to check if record is availble .if yes, it will go to mortgagor information table then it does update the record otherwise it will insert new record
  -- IF (@Edit=1)
  --  BEGIN
      --  IF(@ID=1)
			--BEGIN
			--UPDATE Notes set MediationCaseInformationID =@MediationCaseInformationID, Notes=@Notes,UserID=@UserID where NotesID=@NotesID 
		--	UPDATE Notes set  Notes=@Notes where NotesID=@NotesID                 
   --  SET @outputNotesID = @NotesID;
 --    END
   -- ELSE IF (@Edit=0)
    --BEGIN
    -- Insert statements for procedure here
    
			INSERT INTO Notes (MediationCaseInformationID,Notes) values(@MediationCaseInformationID,@Notes)
			--INSERT INTO Notes (Notes) values(@Notes)
		   -- SET @outputNotesID=SCOPE_IDENTITY()
         --   END
          --  RETURN  @outputNotesID
            END

    

GO

