USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspAddMedicationCaseDetails]    Script Date: 02/10/2015 12:04:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Jaheda Meman>
-- UPDATE date: <01/30/15,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspAddMedicationCaseDetails] 
	-- Add the parameters for the stored procedure here
	@MortgagorInformationID int ,
	@MediationCaseInformationInputID int,
	@Edit int,
	@MortgageAccountNumber char(12),
	@DefaultDate smalldatetime,
	@NoticeDate smalldatetime,
	@ReleaseBankruptcyStayDate smalldatetime,
	@PenaltyDays numeric,
	@InitialFee decimal,
	@FirstLetterSentDate smalldatetime,
	@SecondLetterSentDate smalldatetime,
	--@PenaltyFeeCalcDate smalldatetime,
	@ConfCallDeadlineDate smalldatetime,
	@InitialContactDate smalldatetime,
	@PackageSentLenderDate smalldatetime,
	@SchedConferenceDate smalldatetime,
	@ActualConferenceDate smalldatetime,
	@ConfResolveDeadlineDate smalldatetime,
	@ExtensionRequestDate smalldatetime,
	@RequestExtensionByDate smalldatetime,
	@ExtensionExpirationDate smalldatetime,
	@ConfResolutionDate smalldatetime,
	@CounterOfferRejectedBorrower tinyint,
	@WO_FinancialBenefitBorrower tinyint,
	@WO_AgreementInFile tinyint,
	@CoordinatorID smallint,
	@CounselorID smallint,
	@ConferenceResultID smallint,
	@MediationInvoiceID smallint,
	@Income decimal(14,2),
	--MEDIATION CASE PARAMETER -PANEL 3 IN MEDIATION CASE FORM
	@CertificateNoticeID smallint,
	--@CertificateNoticeReasonID smallint,
	@CertificateNoticePrintDate smalldatetime,
	@CertificateLenderName varchar(160),
	@PenaltyAmount  decimal(14,2),
	@PenaltyPaidDate smalldatetime,
	@MedInvoiceLetterDate smalldatetime,
	@MediationFeeDate smalldatetime,
	@MediationFeeAmount decimal,
	@CertificateLetterReprintDate smalldatetime,
		--MEDIATION CASE PARAMETER -PANEL 4 IN MEDIATION CASE FORM
	@LenderContactID int,
	@AttorneyContactID int,
	@MediationContactID int,
	@ServicerContactID int,
	@CertificateLetterContactID int,
	@MediationCaseInformationID int output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
-- UPDATE MEDICATION CASE HERE
IF (@Edit=1)
    BEGIN
    UPDATE MediationCaseInformation SET 
    	                               --UPDATE MEDIATION CASE FIELDS -PANEL 1 IN MEDIATION CASE FORM
										MortgageAccountNumber=@MortgageAccountNumber,
										InitialFee=@InitialFee,
										--PenaltyFeeCalcDate=@PenaltyFeeCalcDate,
										ReleaseBankruptcyStayDate=@ReleaseBankruptcyStayDate,
										PenaltyDays=@PenaltyDays,
										FirstLetterSentDate=@FirstLetterSentDate,
										SecondLetterSentDate=@SecondLetterSentDate,
										ConfCallDeadlineDate=@ConfCallDeadlineDate,
										--UPDATE MEDIATION CASE CONTACTS -PANEL 2 IN MEDIATION CASE FORM
										InitialContactDate=@InitialContactDate,
										PackageSentLenderDate=@PackageSentLenderDate,
										SchedConferenceDate=@SchedConferenceDate,
										ActualConferenceDate=@ActualConferenceDate,
										MedInvoiceLetterDate=@MedInvoiceLetterDate,
										ConfResolveDeadlineDate=@ConfResolveDeadlineDate,
										ExtensionRequestDate=@ExtensionRequestDate,
										RequestExtensionByDate=@RequestExtensionByDate,
										ExtensionExpirationDate=@ExtensionExpirationDate,
										ConfResolutionDate=@ConfResolutionDate,
										CounterOfferRejectedBorrower=@CounterOfferRejectedBorrower,
	                                    WO_FinancialBenefitBorrower=@WO_FinancialBenefitBorrower,
	                                    WO_AgreementInFile=@WO_AgreementInFile,
	                                    CoordinatorID=@CoordinatorID,
	                                    CounselorID= @CounselorID,
										ConferenceResultID=@ConferenceResultID,
										MediationInvoiceID=@MediationInvoiceID,
										Income=@Income,
										--UPDATE MEDIATION CASE CONTACTS -PANEL 3 IN MEDIATION CASE FORM
										 CertificateNoticeID=@CertificateNoticeID,
	                                    -- CertificateNoticeReasonID=@CertificateNoticeReasonID,
	                                     CertificateNoticePrintDate=@CertificateNoticePrintDate,
	                                     CertificateLenderName=@CertificateLenderName,
	                                     PenaltyAmount=@PenaltyAmount,
	                                     PenaltyPaidDate=@PenaltyPaidDate,
	                                     MediationFeeDate=@MediationFeeDate,
	                                     MediationFeeAmount= @MediationFeeAmount,
	                                     CertificateLetterReprintDate= @CertificateLetterReprintDate,
										--UPDATE MEDIATION CASE CONTACTS -PANEL 4 IN MEDIATION CASE FORM
										LenderContactID=@LenderContactID,
										MediationContactID=@MediationContactID,
										CertificateLetterContactID=@CertificateLetterContactID,
										AttorneyContactID=@AttorneyContactID,
										ServicerContactID=@ServicerContactID
                                  
                                  WHERE MediationCaseInformationID = @MediationCaseInformationInputID
                                  SET @MediationCaseInformationID=@MediationCaseInformationInputID
                                  END
  ElSE
  BEGIN

    -- Insert statements for procedure here
	INSERT INTO MediationCaseInformation ( 
	                                      --INSERT MEDIATION CASE FIELDS -PANEL 1 IN MEDIATION CASE FORM
											MortgagorInformationID,
											MortgageAccountNumber,
											DefaultDate,
										    NoticeDate,
										    ReleaseBankruptcyStayDate,
										    PenaltyDays,
										    InitialFee,
											FirstLetterSentDate,
											SecondLetterSentDate,
											---PenaltyFeeCalcDate,
											ConfCallDeadlineDate,
											--INSERT MEDIATION CASE FIELDS -PANEL 2 IN MEDIATION CASE FORM
											InitialContactDate,
										    PackageSentLenderDate,
										    SchedConferenceDate,
										    ActualConferenceDate,
										    ConfResolveDeadlineDate,
										    ExtensionRequestDate,
										    MedInvoiceLetterDate,
										    RequestExtensionByDate,
										    ExtensionExpirationDate,
										    ConfResolutionDate,
										    CounterOfferRejectedBorrower,
	                                        WO_FinancialBenefitBorrower,
	                                        WO_AgreementInFile,
	                                        CoordinatorID,
	                                        CounselorID,
										    ConferenceResultID,
										    MediationInvoiceID,
										    Income,
										    --INSERT MEDIATION CASE FIELDS -PANEL 4 IN MEDIATION CASE FORM
										    CertificateNoticeID,
	                                        --CertificateNoticeReasonID,
	                                        CertificateNoticePrintDate,
											CertificateLenderName,
											PenaltyAmount,
											PenaltyPaidDate,
											MediationFeeDate,
											MediationFeeAmount,
											CertificateLetterReprintDate,
										    --INSERT MEDIATION CASE FIELDS -PANEL 4 IN MEDIATION CASE FORM
											LenderContactID,
											MediationContactID,
											ServicerContactID,
											AttorneyContactID,
											CertificateLetterContactID
											)
	VALUES(
	--INSERT MEDIATION CASE FIELDS -PANEL 1 IN MEDIATION CASE FORM
	@MortgagorInformationID,
	@MortgageAccountNumber,
	@DefaultDate,
	@NoticeDate,
	@ReleaseBankruptcyStayDate,
	@PenaltyDays,
	@InitialFee,
	@FirstLetterSentDate,
	@SecondLetterSentDate,
	--@PenaltyFeeCalcDate,
	@ConfCallDeadlineDate,
	
	--INSERT MEDIATION CASE FIELDS -PANEL 2 IN MEDIATION CASE FORM
	@InitialContactDate,
	@PackageSentLenderDate,
	@SchedConferenceDate,
	@ActualConferenceDate,
	@MedInvoiceLetterDate,
	@ConfResolveDeadlineDate,
	@ExtensionRequestDate,
	@RequestExtensionByDate,
    @ExtensionExpirationDate,
    @ConfResolutionDate,
    @CounterOfferRejectedBorrower,
	@WO_FinancialBenefitBorrower,
	@WO_AgreementInFile,
	@CoordinatorID,
    @CounselorID,
	@ConferenceResultID,
	@MediationInvoiceID,
	@Income,
	  --INSERT MEDIATION CASE FIELDS -PANEL 3 IN MEDIATION CASE FORM
	@CertificateNoticeID,
	--@CertificateNoticeReasonID,
	@CertificateNoticePrintDate,
	@CertificateLenderName,
	@PenaltyAmount,
	@PenaltyPaidDate,
	@MediationFeeDate,
	@MediationFeeAmount,
	@CertificateLetterReprintDate,
	--INSERT MEDIATION CASE FIELDS -PANEL 4 IN MEDIATION CASE FORM
	@LenderContactID,
	@MediationContactID,
	@ServicerContactID,
	@AttorneyContactID,
	@CertificateLetterContactID
	)


	
	SET @MediationCaseInformationID=SCOPE_IDENTITY()
END
    RETURN  @MediationCaseInformationID
										

END

GO

