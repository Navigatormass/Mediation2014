USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspGetMediationContactsDetails]    Script Date: 02/10/2015 12:06:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Jaheda Meman>
-- Update date: <10/24/14,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspGetMediationContactsDetails]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	IF(@ID=1)
	BEGIN
	SELECT  
	LenderContact.LenderContactID as ID,ISNULL(LenderName,'')+', '+Isnull(ContactName,'')+','+ISNULL(Address_1,'') as Name  from LenderContact ORDER BY Name
	END	
	ELSE IF(@ID=2)
	BEGIN
	SELECT AttorneyContactID as ID,ISnull(LawFirmName,'')+', '+Isnull(AttorneyName,'')+','+ISNULL(Address_1,'') as Name from AttorneyContact ORDER BY Name
	END
    ELSE IF(@ID=3)
	BEGIN
	SELECT CertificateLetterContactID as ID,isnull(AgencyName,'')+', '+isnull(ContactName,'')+','+ISNULL(Address_1,'') as Name from CertificateLetterContact ORDER BY Name
	END
    ELSE IF(@ID=4)
	BEGIN
	SELECT MediationContactID as ID,isnull(AgencyName,'')+', '+isnull(MediationContactName,'')+','+ISNULL(Address_1,'') as Name from MediationContact ORDER BY Name
	END
	ELSE IF(@ID=5)
	BEGIN
	SELECT ServicerContactID as ID,isnull(AgencyName,'')+', '+isnull(ServicerName,'')+','+ISNULL(Address_1,'') as Name from ServicerContact ORDER BY Name
	END
	RETURN
END

GO

