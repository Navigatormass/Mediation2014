USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[spAddMedicationCaseDetails]    Script Date: 02/10/2015 10:06:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Jaheda Meman>
-- Create date: <09/19/14,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAddMedicationCaseDetails] 
	-- Add the parameters for the stored procedure here
	@MortgagorInformationID int ,
	@MortgageAccountNumber char(10),
	@DefaultDate smalldatetime,
	@NoticeDate smalldatetime,
	@ReleaseBankruptcyStayDate smalldatetime,
	@PenaltyDays numeric,
	@InitialFee decimal,
	@FirstLetterSentDate smalldatetime,
	@SecondLetterSentDate smalldatetime,
	@PenaltyFeeCalcDate smalldatetime,
	@ConfCallDeadlineDate smalldatetime,
	@InitialContactDate smalldatetime,
	@MediationCaseInformationID int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into MediationCaseInformation ( 
											MortgagorInformationID,
											MortgageAccountNumber,
											DefaultDate,
										    NoticeDate,
										    ReleaseBankruptcyStayDate,
										    PenaltyDays,
										    InitialFee,
											FirstLetterSentDate,
											SecondLetterSentDate,
											PenaltyFeeCalcDate,
											ConfCallDeadlineDate,
											InitialContactDate)
	Values(
	
	@MortgagorInformationID,
	@MortgageAccountNumber,
	@DefaultDate,
	@NoticeDate,
	@ReleaseBankruptcyStayDate,
	@PenaltyDays,
	@InitialFee,
	@FirstLetterSentDate,
	@SecondLetterSentDate,
	@PenaltyFeeCalcDate,
	@ConfCallDeadlineDate,
	@InitialContactDate)
	
	SET @MediationCaseInformationID=SCOPE_IDENTITY()

    RETURN  @MediationCaseInformationID
											
	
	
				
END

GO

