USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspGetContactDetailsByID]    Script Date: 02/10/2015 12:05:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Jaheda Meman>
-- Update date: <10/17/14,,>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[uspGetContactDetailsByID]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Contactid int
AS
Begin
	If(@ID=1)
	begin
	SELECT LenderName as Name,ContactName as ContactName,ContactTitle as Title, * from LenderContact where LenderContactID=@Contactid
	end
	else If(@ID=2)
	begin
	SELECT LawFirmName  as Name,AttorneyName as ContactName,'' as Title,* from AttorneyContact where AttorneyContactID=@Contactid
	end
    else If(@ID=3)
	begin
	SELECT AgencyName as Name,ContactName as ContactName,ContactTitle as Title,* from CertificateLetterContact where CertificateLetterContactID=@Contactid
	end
    else If(@ID=4)
	begin
	SELECT  AgencyName as Name,MediationContactName as ContactName,'' as Title,* from MediationContact where MediationContactID=@Contactid
	end
		else If(@ID=5)
	begin
	SELECT AgencyName as Name,ServicerName as ContactName,'' as Title,* from ServicerContact where ServicerContactID=@Contactid
	end
	RETURN
END

GO

