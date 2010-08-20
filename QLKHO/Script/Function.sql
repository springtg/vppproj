USE [VPPDB]
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON

--bat dau kiem tra, va dop doi tung khi co ton tai
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextSUPPLIERID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextSUPPLIERID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextCATALOGID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextCATALOGID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextGROUPID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextGROUPID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextITEMID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextITEMID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextDEPARTMENTID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextDEPARTMENTID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextWARE_HOUSEID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextWARE_HOUSEID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextUNITID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextUNITID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextUSERID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextUSERID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextUSER_ROLEID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextUSER_ROLEID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextTAKE_INID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextTAKE_INID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextTAKE_IN_DETAILID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextTAKE_IN_DETAILID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextTAKE_OUTID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextTAKE_OUTID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextTAKE_OUT_DETAILID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextTAKE_OUT_DETAILID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextINVENTORYID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextINVENTORYID]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[nextINVENTORY_DETAILID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[nextINVENTORY_DETAILID]

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_SUPPLIER theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextSUPPLIERID](@id int = 0) 
returns char(5)
AS
begin
 return 'NCC' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_CATALOG theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextCATALOGID](@id int = 0) 
returns char(5)
AS
begin
 return 'DM' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_GROUP theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextGROUPID](@id int = 0) 
returns char(5)
AS
begin
 return 'NH' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_ITEM theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextITEMID](@id int = 0) 
returns char(5)
AS
begin
 return 'MH' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_DEPARTMENT theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextDEPARTMENTID](@id int = 0) 
returns char(5)
AS
begin
 return 'PB' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_WARE_HOUSE theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextWARE_HOUSEID](@id int = 0) 
returns char(5)
AS
begin
 return 'KHO' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_UNIT theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextUNITID](@id int = 0) 
returns char(5)
AS
begin
 return 'DV' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_USER theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextUSERID](@id int = 0) 
returns char(5)
AS
begin
 return 'ND' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_USER_ROLE theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextUSER_ROLEID](@id int = 0) 
returns char(5)
AS
begin
 return 'QND' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_TAKE_IN theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextTAKE_INID](@id int = 0) 
returns char(5)
AS
begin
 return 'NK' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_TAKE_IN_DETAIL theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextTAKE_IN_DETAILID](@id int = 0) 
returns char(5)
AS
begin
 return 'CHK' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_TAKE_OUT theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextTAKE_OUTID](@id int = 0) 
returns char(5)
AS
begin
 return 'XK' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_TAKE_OUT_DETAIL theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextTAKE_OUT_DETAILID](@id int = 0) 
returns char(5)
AS
begin
 return 'CXK' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_INVENTORY theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextINVENTORYID](@id int = 0) 
returns char(5)
AS
begin
 return 'TK' + right('000'+convert(varchar(10),@id),3)
end

go
-- =============================================
-- Author:  Thanh Xuan
-- Create date: 19/08/2010
-- Description: Tao ID ke tiep VPP_INVENTORY_DETAIL theo 1 dinh dang nao do
-- =============================================
CREATE FUNCTION [dbo].[nextINVENTORY_DETAILID](@id int = 0) 
returns char(5)
AS
begin
 return 'CTK' + right('000'+convert(varchar(10),@id),3)
end
