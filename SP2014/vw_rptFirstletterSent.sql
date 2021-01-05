USE [Medprodtest]
GO

/****** Object:  View [dbo].[vw_rptFirstletterSent]    Script Date: 02/10/2015 12:24:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_rptFirstletterSent]
AS
SELECT     dbo.MediationCaseInformation.MediationCaseInformationID, dbo.MortgagorInformation.MortgagorInformationID, ISNULL(UPPER(dbo.MortgagorInformation.FirstName), 
                      '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.MiddleInitial), '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.LastName), '') AS Name, 
                      ISNULL(UPPER(dbo.MortgagorInformation.Co_FirstName), '') + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.Co_MiddleInitial), '') 
                      + ' ' + ISNULL(UPPER(dbo.MortgagorInformation.Co_LastName), '') AS CoFullName, UPPER(dbo.MortgagorInformation.Address_1) AS Address, 
                      UPPER(dbo.MortgagorInformation.Address_2) AS Address_2, ISNULL(UPPER(dbo.MortgagorInformation.City) + ', ', '') + ISNULL(UPPER(dbo.MortgagorInformation.State)
                       + ' ', '') + ISNULL(dbo.MortgagorInformation.ZipCode, '') AS CityStateZip, UPPER(dbo.MortgagorInformation.Address_1) 
                      + (CASE WHEN MortgagorInformation.Address_2 > '' THEN ', ' + UPPER(MortgagorInformation.Address_2 + ', ') ELSE ', ' END) + UPPER(dbo.MortgagorInformation.City) 
                      + ', ' + UPPER(dbo.MortgagorInformation.State) + ' ' + UPPER(dbo.MortgagorInformation.ZipCode) AS AddressCityStateZip, 
                      dbo.MediationCaseInformation.MediationCaseInformationID AS Expr1, dbo.MediationCaseInformation.FirstLetterSentDate, dbo.MediationCaseInformation.CreateDate, 
                      dbo.MediationCaseInformation.NoticeDate
FROM         dbo.MortgagorInformation INNER JOIN
                      dbo.MediationCaseInformation ON dbo.MortgagorInformation.MortgagorInformationID = dbo.MediationCaseInformation.MortgagorInformationID
WHERE     (dbo.MediationCaseInformation.FirstLetterSentDate IS NULL)


GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "MortgagorInformation"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MediationCaseInformation"
            Begin Extent = 
               Top = 6
               Left = 282
               Bottom = 125
               Right = 523
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_rptFirstletterSent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_rptFirstletterSent'
GO

