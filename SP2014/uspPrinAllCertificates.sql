USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspPrinAllCertificates]    Script Date: 02/10/2015 12:07:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspPrinAllCertificates]
--@FromNoticeDate smalldatetime,
--@ToNoticeDate smalldatetime
@MediationCaseInformationID int,
@ReportID int

    /*
    (
    @parameter1 int = 5,
    @parameter2 datatype OUTPUT 
    )
    */
AS

if(exists(select MediationCaseInformationID from MediationCaseInformation where MediationCaseInformationID = @MediationCaseInformationID and CertificateNoticePrintDate is null))
begin
update MediationCaseInformation set CertificateNoticeID=@ReportID , CertificateNoticePrintDate=getdate() where MediationCaseInformationID = @MediationCaseInformationID 
end
else
begin
update MediationCaseInformation set CertificateNoticeID=@ReportID , CertificateLetterReprintDate=getdate() where MediationCaseInformationID = @MediationCaseInformationID 

end


Begin	
if(@ReportID=1 or @ReportID=2)
begin
SELECT     dbo.MediationCaseInformation.MediationCaseInformationID, dbo.MediationCaseInformation.CertificateLenderName, dbo.LenderContact.LenderName, 
                      ISNULL(NULLIF (dbo.MediationCaseInformation.CertificateLenderName, ' '), dbo.LenderContact.LenderName) AS LenderAgencyName, 
                      dbo.MediationCaseInformation.LenderContactID, dbo.CertificateLetterContact.AgencyName AS CertLenderName, 
                      dbo.CertificateLetterContact.ContactName AS clcContactName, dbo.MediationCaseInformation.CertificateNoticePrintDate, 
                      dbo.MediationCaseInformation.MortgagorInformationID, dbo.MediationCaseInformation.ConfCallDeadlineDate, dbo.MediationCaseInformation.CoordinatorID, 
                      dbo.MediationCaseInformation.PenaltyAmount, dbo.MediationCaseInformation.PenaltyPaidDate, dbo.MediationCaseInformation.CertificateLetterContactID, 
                      dbo.CertificateLetterContact.ContactTitle AS clcContactTitle, dbo.CertificateLetterContact.Address_1 AS clcAddress1, 
                      dbo.CertificateLetterContact.Address_2 AS clcAddress2, dbo.CertificateLetterContact.City AS clcCity, dbo.CertificateLetterContact.State AS clcState, 
                      dbo.CertificateLetterContact.ZipCode AS clcZip, dbo.CertificateLetterContact.Email, dbo.CertificateLetterContact.OfficePhone, dbo.CertificateLetterContact.Extension, 
                      dbo.CertificateLetterContact.FaxNumber, dbo.CertificateLetterContact.UserID, dbo.MortgagorInformation.FirstName AS borrowerFirst, 
                      dbo.MortgagorInformation.LastName AS borrowerLast, dbo.MortgagorInformation.Co_FirstName, dbo.MortgagorInformation.Co_LastName, 
                      dbo.MortgagorInformation.Address_1 AS propertyAddress1, dbo.MortgagorInformation.Address_2 AS propertyAddress2, 
                      dbo.Coordinator.FirstName + ' ' + dbo.Coordinator.LastName AS StaffName, dbo.MortgagorInformation.City AS propertyCity, 
                      dbo.MortgagorInformation.ZipCode AS propertyZip, dbo.MortgagorInformation.State AS propertyState,dbo.MortgagorInformation.createdate as createdate,UPPER(dbo.MortgagorInformation.Address_1) AS Address, 
                      UPPER(dbo.MortgagorInformation.Address_2) AS Address_2, ISNULL(UPPER(dbo.MortgagorInformation.City) + ', ', '') + ISNULL(UPPER(dbo.MortgagorInformation.State)
                       + ' ', '') + ISNULL(dbo.MortgagorInformation.ZipCode, '') AS CityStateZip, UPPER(dbo.MortgagorInformation.Address_1) 
                      + (CASE WHEN MortgagorInformation.Address_2 > '' THEN ', ' + UPPER(MortgagorInformation.Address_2 + ', ') ELSE ', ' END) + UPPER(dbo.MortgagorInformation.City) 
                      + ', ' + UPPER(dbo.MortgagorInformation.State) + ' ' + UPPER(dbo.MortgagorInformation.ZipCode) AS AddressCityStateZip,  dbo.Counselor.CounselorID, 
                      dbo.Counselor.FirstName AS CounselorFirst, dbo.Counselor.LastName AS CounselorLast, ISNULL(UPPER(dbo.MortgagorInformation.FirstName), '') 
                      + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.MiddleInitial), '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.LastName), '') AS Name
FROM         dbo.MediationCaseInformation INNER JOIN
                      dbo.MortgagorInformation ON dbo.MediationCaseInformation.MortgagorInformationID = dbo.MortgagorInformation.MortgagorInformationID LEFT OUTER JOIN
                      dbo.Counselor ON dbo.MediationCaseInformation.CounselorID = dbo.Counselor.CounselorID LEFT OUTER JOIN
                      dbo.Coordinator ON dbo.MediationCaseInformation.CoordinatorID = dbo.Coordinator.CoordinatorID LEFT OUTER JOIN
                      dbo.CertificateLetterContact ON dbo.MediationCaseInformation.CertificateLetterContactID = dbo.CertificateLetterContact.CertificateLetterContactID LEFT OUTER JOIN
                      dbo.LenderContact ON dbo.MediationCaseInformation.LenderContactID = dbo.LenderContact.LenderContactID
                      
                      
                     where (dbo.MediationCaseInformation.ConfCallDeadlineDate < GETDATE() - 1) AND 
                      (dbo.MediationCaseInformation.CounselorID IS NULL) AND (dbo.MediationCaseInformation.CertificateLetterContactID > 0) AND 
                      (dbo.MediationCaseInformation.PenaltyAmount > 0) AND (dbo.MediationCaseInformation.PenaltyPaidDate IS NOT NULL) 
                      OR
                      (dbo.MediationCaseInformation.CertificateNoticePrintDate IS NULL) 
                      AND (dbo.MediationCaseInformation.ConfCallDeadlineDate < GETDATE() - 1) AND 
                      (dbo.MediationCaseInformation.CounselorID IS NULL) AND  dbo.MediationCaseInformation.MediationCaseInformationID=@MediationCaseInformationID AND (dbo.MediationCaseInformation.CertificateLetterContactID > 0)
                       AND (dbo.MediationCaseInformation.PenaltyAmount = 0) AND (dbo.MediationCaseInformation.PenaltyPaidDate IS NULL) 
                ORDER BY MediationCaseInformation.MediationCaseInformationID ASC
         -- ((DAY, MediationCaseInformation.CreateDate), GETDATE()) > 60) ORDER BY MediationCaseInformation.MediationCaseInformationID ASC
          --((MediationCaseInformation.CreateDate,DATEPART(DAY,GETDATE())> 60) ORDER BY MediationCaseInformation.MediationCaseInformationID ASC
           /* SET NOCOUNT ON */
           end
           else if(@ReportID=3 or @ReportID=4)
           begin
           SELECT     dbo.MediationCaseInformation.MediationCaseInformationID, dbo.MediationCaseInformation.CertificateLenderName, dbo.LenderContact.LenderName, 
                      dbo.CertificateLetterContact.AgencyName AS CertLenderName, dbo.CertificateLetterContact.ContactName AS clcContactName, 
                      dbo.MediationCaseInformation.CertificateNoticePrintDate, dbo.MediationCaseInformation.PenaltyAmount, 
                      dbo.MediationCaseInformation.PenaltyPaidDate, dbo.MediationCaseInformation.CertificateLetterContactID, 
                      dbo.CertificateLetterContact.ContactTitle AS clcContactTitle, dbo.CertificateLetterContact.Address_1 AS clcAddress1, 
                      dbo.CertificateLetterContact.Address_2 AS clcAddress2, dbo.CertificateLetterContact.City AS clcCity, dbo.MediationCaseInformation.CertificateNoticeID, 
                      dbo.MortgagorInformation.EstateOf, dbo.MortgagorInformation.FirstName AS borrowerFirst, dbo.MortgagorInformation.LastName AS borrowerLast, 
                      dbo.MortgagorInformation.Alias AS Bo_Alias, dbo.MortgagorInformation.PrimaryPhone AS Bo_PrimaryPhone, 
                      dbo.MortgagorInformation.CellPhone AS Bo_CellPhone, dbo.MortgagorInformation.Hispanic AS Bo_Hispanic, 
                      dbo.MortgagorInformation.Email AS Bo_Email, dbo.CertificateLetterContact.State AS clcState, dbo.CertificateLetterContact.ZipCode AS clcZip, 
                      dbo.MortgagorInformation.Co_FirstName, dbo.MortgagorInformation.Co_LastName, dbo.MortgagorInformation.Address_1 AS propertyAddress1, 
                      dbo.MortgagorInformation.Address_2 AS propertyAddress2, dbo.MortgagorInformation.Prefix AS Bo_Prefix, 
                      dbo.MortgagorInformation.MiddleInitial AS Bo_MiddleInitial, dbo.MortgagorInformation.Suffix AS Bo_Suffix, 
                      dbo.MortgagorInformation.Gender AS Bo_Gender, dbo.MortgagorInformation.UserID AS Bo_UserID, 
                      dbo.MortgagorInformation.CreateDate AS Bo_CreateDate, dbo.MortgagorInformation.Co_Alias, dbo.MortgagorInformation.Co_BorrowerPhone, 
                      dbo.MortgagorInformation.Co_Prefix, dbo.MortgagorInformation.Co_MiddleInitial, dbo.MortgagorInformation.Co_Suffix, 
                      dbo.MortgagorInformation.City AS propertyCity, dbo.MortgagorInformation.ZipCode AS propertyZip, dbo.MortgagorInformation.State AS propertyState, 
                      dbo.Coordinator.FirstName + ' ' + dbo.Coordinator.LastName AS StaffName, dbo.Counselor.CounselorID, dbo.Counselor.FirstName AS CounselorFirst, 
                      dbo.Counselor.LastName AS CounselorLast
FROM         dbo.MediationCaseInformation INNER JOIN
                      dbo.MortgagorInformation ON 
                      dbo.MediationCaseInformation.MortgagorInformationID = dbo.MortgagorInformation.MortgagorInformationID LEFT OUTER JOIN
                      dbo.CertificateNotice ON dbo.MediationCaseInformation.CertificateNoticeID = dbo.CertificateNotice.CertificateNoticeID LEFT OUTER JOIN
                      dbo.Counselor ON dbo.MediationCaseInformation.CounselorID = dbo.Counselor.CounselorID LEFT OUTER JOIN
                      dbo.Coordinator ON dbo.MediationCaseInformation.CoordinatorID = dbo.Coordinator.CoordinatorID LEFT OUTER JOIN
                      dbo.CertificateLetterContact ON 
                      dbo.MediationCaseInformation.CertificateLetterContactID = dbo.CertificateLetterContact.CertificateLetterContactID LEFT OUTER JOIN
                      dbo.LenderContact ON dbo.MediationCaseInformation.LenderContactID = dbo.LenderContact.LenderContactID
WHERE                   dbo.MediationCaseInformation.MediationCaseInformationID=@MediationCaseInformationID 
                       

           end
           
           
           else if(@ReportID=5 or @ReportID=6 )
           BEGIN
           SELECT     dbo.MediationCaseInformation.MediationCaseInformationID, dbo.MediationCaseInformation.AttorneyContactID, 
                      dbo.AttorneyContact.LawFirmName AS AttorneyAgencyName, dbo.AttorneyContact.AttorneyName AS AttorneyContactName, 
                      ISNULL(NULLIF (dbo.AttorneyContact.Address_1, ''), '') + ISNULL(', ' + NULLIF (dbo.AttorneyContact.Address_2, ''), '') AS AttorneyContactAddress1, 
                      ISNULL(dbo.AttorneyContact.City + ', ', '') + ISNULL(dbo.AttorneyContact.State + '  ', '') + dbo.AttorneyContact.ZipCode AS AttorneyContactAddress2, 
                      dbo.MediationCaseInformation.MediationContactID, dbo.MediationContact.AgencyName AS MediationAgencyName, 
                      dbo.MediationContact.MediationContactName, dbo.MediationContact.ContactTitle AS MediationContactTitle, 
                      ISNULL(NULLIF (dbo.MediationContact.Address_1, ''), '') + ISNULL(', ' + NULLIF (dbo.MediationContact.Address_2, ''), '') AS MediationContactAddress1, 
                      ISNULL(dbo.MediationContact.City + ', ', '') + dbo.MediationContact.State + '  ' + dbo.MediationContact.ZipCode AS MediationContactAddress2, 
                      dbo.MediationCaseInformation.MediationInvoiceID, dbo.MediationCaseInformation.ConfResolveDeadlineDate, 
                      dbo.MediationCaseInformation.ActualConferenceDate, dbo.MediationCaseInformation.ServicerContactID, 
                      dbo.ServicerContact.AgencyName AS ServicerAgencyName, dbo.ServicerContact.ServicerName AS ServiceContactName, 
                      dbo.ServicerContact.ServicerTitle AS ServiceContactTitle, ISNULL(NULLIF (dbo.ServicerContact.Address_1, ''), '') 
                      + ISNULL(', ' + NULLIF (dbo.ServicerContact.Address_2, ''), '') AS ServicerContactAddress1, ISNULL(dbo.ServicerContact.City + ', ', '') 
                      + ISNULL(dbo.ServicerContact.State + '  ', '') + dbo.ServicerContact.ZipCode AS ServicerContactAddress2, dbo.MediationInvoice.InvoiceSentDesc, 
                      dbo.MediationCaseInformation.RequestExtensionByDate, dbo.MediationCaseInformation.MortgageAccountNumber, 
                      dbo.MediationCaseInformation.MortgagorInformationID, dbo.MortgagorInformation.EstateOf, dbo.MortgagorInformation.Prefix AS Bo_Prefix, 
                      dbo.MortgagorInformation.FirstName AS Bo_FirstName, dbo.MortgagorInformation.MiddleInitial AS Bo_MiddleInitial, 
                      dbo.MortgagorInformation.LastName AS Bo_LastName, dbo.MortgagorInformation.Suffix AS Bo_Suffix, dbo.MortgagorInformation.Alias AS Bo_Alias, 
                      dbo.MortgagorInformation.CellPhone AS Bo_CellPhone, dbo.MortgagorInformation.PrimaryPhone AS Bo_PrimaryPhone, 
                      dbo.MortgagorInformation.Hispanic, dbo.MortgagorInformation.Email AS Bo_Email, dbo.MortgagorInformation.Gender AS Bo_Gender, 
                      dbo.MortgagorInformation.Co_Prefix, dbo.MortgagorInformation.Co_FirstName, dbo.MortgagorInformation.Co_MiddleInitial, 
                      dbo.MortgagorInformation.Co_LastName, dbo.MortgagorInformation.Co_Suffix, dbo.MortgagorInformation.Co_Alias, 
                      dbo.MortgagorInformation.Co_BorrowerPhone, dbo.MortgagorInformation.Address_1 AS PropertyAddress1, 
                      dbo.MortgagorInformation.Address_2 AS PropertyAddress2, dbo.MortgagorInformation.City AS PropertyCity, 
                      dbo.MortgagorInformation.State AS PropertyState, dbo.MortgagorInformation.ZipCode AS PropertyZipcode, 
                      dbo.MediationCaseInformation.CoordinatorID, dbo.Coordinator.FirstName AS CoordinatorFirst, dbo.Coordinator.LastName AS CoordinatorLast
FROM         dbo.MediationCaseInformation INNER JOIN
                      dbo.Coordinator ON dbo.MediationCaseInformation.CoordinatorID = dbo.Coordinator.CoordinatorID INNER JOIN
                      dbo.MortgagorInformation ON 
                      dbo.MediationCaseInformation.MortgagorInformationID = dbo.MortgagorInformation.MortgagorInformationID LEFT OUTER JOIN
                      dbo.MediationInvoice ON dbo.MediationCaseInformation.MediationInvoiceID = dbo.MediationInvoice.MediationInvoiceID LEFT OUTER JOIN
                      dbo.AttorneyContact ON dbo.MediationCaseInformation.AttorneyContactID = dbo.AttorneyContact.AttorneyContactID LEFT OUTER JOIN
                      dbo.MediationContact ON dbo.MediationCaseInformation.MediationContactID = dbo.MediationContact.MediationContactID LEFT OUTER JOIN
                      dbo.ServicerContact ON dbo.MediationCaseInformation.ServicerContactID = dbo.ServicerContact.ServicerContactID
WHERE     
--(dbo.MediationCaseInformation.CertificateNoticePrintDate IS NULL)  AND
 dbo.MediationCaseInformation.MediationCaseInformationID=@MediationCaseInformationID
                     
                     END
          
                     end
    RETURN
GO

