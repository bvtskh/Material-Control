USE [SMT]
GO
/****** Object:  UserDefinedTableType [dbo].[udt_MainSub_LineItem]    Script Date: 10/23/2023 10:00:41 AM ******/
CREATE TYPE [dbo].[udt_MainSub_LineItem] AS TABLE(
	[LINE_ID] [nvarchar](64) NOT NULL,
	[PART_ID] [nvarchar](64) NOT NULL,
	[PRODUCT_ID] [nvarchar](64) NOT NULL,
	[UPD_TIME] [datetime] NOT NULL,
	[WO] [varchar](10) NOT NULL,
	[MATERIAL_ORDER_ID] [nvarchar](50) NOT NULL,
	[ALTER_PART_ID] [nvarchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[udt_Tokusai_LineItem]    Script Date: 10/23/2023 10:00:41 AM ******/
CREATE TYPE [dbo].[udt_Tokusai_LineItem] AS TABLE(
	[LINE_ID] [nvarchar](64) NOT NULL,
	[PART_ID] [nvarchar](64) NOT NULL,
	[PRODUCT_ID] [nvarchar](64) NOT NULL,
	[UPD_TIME] [datetime] NOT NULL,
	[IS_TOKUSAI] [bit] NOT NULL,
	[WO] [nvarchar](10) NOT NULL,
	[IS_DM_ACCEPT] [bit] NULL,
	[MATERIAL_ORDER_ID] [nvarchar](50) NULL
)
GO
/****** Object:  Table [dbo].[ECO_WoChanging]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ECO_WoChanging](
	[ID] [uniqueidentifier] NOT NULL,
	[ORDER_NO] [varchar](10) NOT NULL,
	[ECO_NO] [varchar](50) NOT NULL,
	[MODEL_NO] [nvarchar](50) NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[DUE_DATE] [date] NOT NULL,
	[UPD_DATE] [datetime] NOT NULL,
	[ORDER_TYPE] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Eco_WoChanging] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__ECO_WoCh__460AEC56AB871275] UNIQUE NONCLUSTERED 
(
	[ORDER_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FeederAlarm]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeederAlarm](
	[FEEDER_ID] [nvarchar](50) NOT NULL,
	[LINE_ID] [nvarchar](50) NOT NULL,
	[MACHINE_SETTING] [nvarchar](50) NOT NULL,
	[MACHINE_ID] [nvarchar](50) NOT NULL,
	[MACHINE_SLOT] [int] NOT NULL,
	[EX_DATE] [date] NOT NULL,
	[STATE] [int] NOT NULL,
	[ABOUT] [nvarchar](50) NOT NULL,
	[UPD_TIME] [datetime] NULL,
 CONSTRAINT [PK_FeederAlarm] PRIMARY KEY CLUSTERED 
(
	[FEEDER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LineSetting]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LineSetting](
	[LINE_ID] [varchar](4) NOT NULL,
	[IS_CHECK_RELOAD] [bit] NOT NULL,
	[IS_CHECK_FEEDER] [bit] NOT NULL,
	[IS_CONFIRM_TOKUSAI] [bit] NOT NULL,
	[FEEDER_DAY_USE] [int] NOT NULL,
	[DES] [nvarchar](200) NULL,
	[UPDATE_TIME] [datetime] NOT NULL,
	[UPDATER] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_LineSetting] PRIMARY KEY CLUSTERED 
(
	[LINE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Location]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LineId] [nvarchar](50) NOT NULL,
	[LocationId] [nvarchar](50) NOT NULL,
	[GroupID] [nvarchar](50) NULL,
 CONSTRAINT [PK_Location_1] PRIMARY KEY CLUSTERED 
(
	[LineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log4Net]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log4Net](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [nvarchar](255) NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
	[Logger] [nvarchar](255) NOT NULL,
	[Message] [nvarchar](4000) NOT NULL,
	[Exception] [nvarchar](3000) NULL,
 CONSTRAINT [PK_Log4Net] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MachineIOT]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MachineIOT](
	[MAC_ADDRESS] [nvarchar](50) NOT NULL,
	[HOST_NAME] [nvarchar](50) NOT NULL,
	[IP_ADDRESS] [nvarchar](50) NULL,
	[USER] [nvarchar](50) NULL,
	[LOCATION] [nvarchar](500) NULL,
	[UPDATE_TIME] [datetime] NULL,
	[SLEEP_TIME] [int] NOT NULL,
	[VERSION] [nvarchar](50) NULL,
	[WINDOWS_EDITION] [nvarchar](50) NULL,
	[IS_WINDOWS_ACTIVE] [bit] NULL,
	[IS_WINDOWS_64] [bit] NULL,
 CONSTRAINT [PK_MachineIOT_1] PRIMARY KEY CLUSTERED 
(
	[MAC_ADDRESS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MainSub_LineItem]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainSub_LineItem](
	[LINE_ID] [nvarchar](64) NOT NULL,
	[PRODUCT_ID] [nvarchar](64) NOT NULL,
	[PART_ID] [nvarchar](64) NOT NULL,
	[UPD_TIME] [datetime] NOT NULL,
	[WO] [nvarchar](10) NOT NULL,
	[MATERIAL_ORDER_ID] [nvarchar](64) NOT NULL,
	[ALTER_PART_ID] [nvarchar](50) NULL,
 CONSTRAINT [PK_MainSub_LineItem_2] PRIMARY KEY CLUSTERED 
(
	[LINE_ID] ASC,
	[PRODUCT_ID] ASC,
	[PART_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MainSub_LineItem_backup]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainSub_LineItem_backup](
	[PART_ID] [nvarchar](64) NOT NULL,
	[LINE_ID] [nvarchar](64) NOT NULL,
	[PRODUCT_ID] [nvarchar](64) NOT NULL,
	[UPD_TIME] [datetime] NOT NULL,
	[WO] [nvarchar](10) NOT NULL,
	[MATERIAL_ORDER_ID] [nvarchar](64) NOT NULL,
	[ALTER_PART_ID] [nvarchar](50) NULL,
 CONSTRAINT [PK_MainSub_LineItem_backup_2] PRIMARY KEY CLUSTERED 
(
	[LINE_ID] ASC,
	[PRODUCT_ID] ASC,
	[PART_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MainSub_Model]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MainSub_Model](
	[ID] [varchar](50) NOT NULL,
	[PART_FROM] [nvarchar](50) NOT NULL,
	[PART_TO] [nvarchar](50) NOT NULL,
	[UPD_TIME] [datetime] NOT NULL,
	[UPDATOR] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MainSubChanging] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tokusai_Item]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokusai_Item](
	[LINE_ID] [nvarchar](64) NOT NULL,
	[UPN_ID] [nvarchar](64) NOT NULL,
	[EM_NO] [nvarchar](20) NOT NULL,
	[MATERIAL_ORDER_ID] [nvarchar](64) NOT NULL,
	[PART_ID] [nvarchar](64) NOT NULL,
	[MACHINE_SLOT] [int] NOT NULL,
	[MACHINE_ID] [nvarchar](64) NOT NULL,
	[PRODUCT_ID] [nvarchar](64) NOT NULL,
	[IS_FAILED] [bit] NOT NULL,
	[ERR_TYPE] [int] NOT NULL,
	[PRODUCTION_ORDER_ID] [nvarchar](64) NOT NULL CONSTRAINT [DF_Tokusai_Item_PRODUCTION_ORDER_ID]  DEFAULT (''),
	[QUANTITY] [float] NOT NULL CONSTRAINT [DF_Tokusai_Item_Qty]  DEFAULT ((0)),
	[UPD_TIME] [datetime] NOT NULL,
 CONSTRAINT [PK_Tokusai_Item_1] PRIMARY KEY CLUSTERED 
(
	[UPN_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tokusai_LineConfirm]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tokusai_LineConfirm](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DEPT] [varchar](50) NOT NULL,
	[UPD_TIME] [datetime] NOT NULL,
	[USER_CONFIRM] [nvarchar](50) NOT NULL,
	[RESULT_CONFIRM] [bit] NOT NULL CONSTRAINT [DF_Tokusai_LineConfirm_RESULT_CONFIRM]  DEFAULT ((0)),
	[ID_HISTORY] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Tokusai_LineConfirm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Confirm] UNIQUE NONCLUSTERED 
(
	[ID_HISTORY] ASC,
	[DEPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tokusai_LineHistory]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tokusai_LineHistory](
	[LINE_ID] [nvarchar](64) NOT NULL,
	[PART_ID] [nvarchar](64) NOT NULL,
	[PRODUCT_ID] [nvarchar](64) NOT NULL,
	[UPD_TIME] [datetime] NOT NULL,
	[CHANGE_NAME] [nvarchar](500) NULL,
	[CHANGE_ID] [int] NULL,
	[WO] [varchar](10) NOT NULL,
	[IS_CONFIRM] [bit] NOT NULL CONSTRAINT [DF_Tokusai_LineHistory_IS_CONFIRM]  DEFAULT ((0)),
	[IS_DM_ACCEPT] [bit] NOT NULL CONSTRAINT [DF_Tokusai_LineHistory_IS_DM_ACCEPT]  DEFAULT ((1)),
	[ID] [nvarchar](64) NOT NULL,
	[MATERIAL_ORDER_ID] [nvarchar](64) NOT NULL,
	[MACHINE_ID] [nvarchar](64) NULL,
	[MACHINE_SLOT] [int] NULL,
 CONSTRAINT [PK_Tokusai_LineHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tokusai_LineItem]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tokusai_LineItem](
	[LINE_ID] [nvarchar](64) NOT NULL,
	[PART_ID] [nvarchar](64) NOT NULL,
	[PRODUCT_ID] [nvarchar](64) NOT NULL,
	[MATERIAL_ORDER_ID] [nvarchar](64) NOT NULL,
	[UPD_TIME] [datetime] NOT NULL,
	[IS_TOKUSAI] [bit] NOT NULL,
	[WO] [varchar](10) NOT NULL,
	[IS_DM_ACCEPT] [bit] NOT NULL CONSTRAINT [DF_Tokusai_LineItem_IS_DM_ACCEPT]  DEFAULT ((1)),
 CONSTRAINT [PK_Tokusai_LineItem_1] PRIMARY KEY CLUSTERED 
(
	[LINE_ID] ASC,
	[PART_ID] ASC,
	[PRODUCT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tokusai_LineItem_backup]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tokusai_LineItem_backup](
	[LINE_ID] [nvarchar](64) NOT NULL,
	[PART_ID] [nvarchar](64) NOT NULL,
	[PRODUCT_ID] [nvarchar](64) NOT NULL,
	[MATERIAL_ORDER_ID] [nvarchar](64) NOT NULL,
	[UPD_TIME] [datetime] NOT NULL,
	[IS_TOKUSAI] [bit] NOT NULL,
	[WO] [varchar](10) NOT NULL,
	[IS_DM_ACCEPT] [bit] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tokusai_Plan]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tokusai_Plan](
	[ORDER_NO] [varchar](10) NOT NULL,
	[MODEL_NO] [nvarchar](50) NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[DUE_DATE] [date] NOT NULL,
	[UPD_DATE] [datetime] NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[ORDER_TYPE] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Tokusai_Plan_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Tokusai___460AEC569241E81F] UNIQUE NONCLUSTERED 
(
	[ORDER_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Tokusai_LineItem_backup] ADD  CONSTRAINT [DF_Tokusai_LineItem_IS_DM_ACCEPT_1]  DEFAULT ((1)) FOR [IS_DM_ACCEPT]
GO
/****** Object:  StoredProcedure [dbo].[GetAllSetting]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSetting]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT t1.LINE_ID,t1.IS_CHECK_RELOAD, t1.IS_CHECK_FEEDER FROM [SMT].[dbo].[LineSetting] t1
END

GO
/****** Object:  StoredProcedure [dbo].[GetTokusaiECOPlan]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTokusaiECOPlan]
AS
BEGIN
	
	SET NOCOUNT ON;
	select ORDER_NO as WO,ORDER_TYPE as 'WO Type',MODEL_NO as MODEL,QUANTITY as 'WO Qty',DUE_DATE as 'Plan Date',ECO_NO as 'ECO NO' from ECO_WoChanging 
	union all
	select ORDER_NO as WO,ORDER_TYPE as 'WO Type',MODEL_NO as MODEL,QUANTITY as 'WO Qty',DUE_DATE as 'Plan Date',ECO_NO = '' from  Tokusai_Plan

END

GO
/****** Object:  StoredProcedure [dbo].[MainSub_LineItem_Update]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROC [dbo].[MainSub_LineItem_Update]
                            (
                                @Data AS [dbo].[udt_MainSub_LineItem] READONLY
                            )
                            AS
                            BEGIN
                                MERGE [dbo].[MainSub_LineItem] AS [Target]
                                USING @Data AS [Source]
                                ON [Source].[LINE_ID] = [Target].[LINE_ID]
									and [Source].PRODUCT_ID = [Target].PRODUCT_ID
									and [Source].PART_ID = [Target].PART_ID
                                -- For Inserts
                                WHEN NOT MATCHED BY target THEN
                                    INSERT
                                    (
										LINE_ID,
										PART_ID,
										PRODUCT_ID,
										UPD_TIME,
										MATERIAL_ORDER_ID,
										WO,
										ALTER_PART_ID
									)
                                    VALUES
                                    (
										[Source].[LINE_ID],
										[Source].PART_ID,
										[Source].PRODUCT_ID,
										[Source].UPD_TIME,
										[Source].MATERIAL_ORDER_ID,
										[Source].WO,
										[Source].ALTER_PART_ID
								     )
								
                                -- For Updates
                                WHEN MATCHED THEN
									   UPDATE SET 
										[Target].UPD_TIME = [Source].UPD_TIME,
										[Target].MATERIAL_ORDER_ID = [Source].MATERIAL_ORDER_ID,
										[Target].WO = [Source].WO,
										[Target].ALTER_PART_ID = [Source].ALTER_PART_ID;
										
                            END;


GO
/****** Object:  StoredProcedure [dbo].[SMT_Tokusai]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SMT_Tokusai]
		@partNo nvarchar(64)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT TOP 1000 *
  FROM [UMCVN_BASE].[dbo].[WH_Tokusai]
  where PART_TO = @partNo
END

GO
/****** Object:  StoredProcedure [dbo].[Tokusai_GetAllLineConfirm]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tokusai_GetAllLineConfirm]
	-- Add the parameters for the stored procedure here
	 (
         @IsOnline  bit,
		 @IsECO  bit
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select CONVERT(varchar(36), h.ID) as ID,h.LINE_ID,h.PART_ID,h.WO,h.CHANGE_NAME,h.UPD_TIME as TIME_STOP,h.PRODUCT_ID,c.DEPT,c.UPD_TIME as TIME_CONFIRM,c.USER_CONFIRM, 
case when c.RESULT_CONFIRM = 0 then 'NG'
	when c.RESULT_CONFIRM = 1 then 'OK'
	end as RESULT,
	h.IS_DM_ACCEPT,
	h.MACHINE_SLOT
 from Tokusai_LineHistory as h 
 left join Tokusai_LineConfirm as c on h.ID = c.ID_HISTORY 
 where 
	h.IS_CONFIRM = 0
	and (
	(@IsOnline = 1 and @IsECO = 0 and h.WO not in (select ORDER_NO from ECO_WoChanging))
	or (@IsECO = 1 and @IsOnline = 0 and h.WO in (select ORDER_NO from ECO_WoChanging))
	or (@IsECO = 1 and @IsOnline = 1)
	)
 ORDER bY TIME_STOP DESC
END


GO
/****** Object:  StoredProcedure [dbo].[Tokusai_GetAllLineConfirmCompleted]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tokusai_GetAllLineConfirmCompleted]
	-- Add the parameters for the stored procedure here
	 (
         @IsOnline  bit,
		 @IsECO  bit
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select TOP(1000) CONVERT(varchar(36), h.ID) as ID,h.LINE_ID,h.PART_ID,h.WO,h.CHANGE_NAME,h.UPD_TIME as TIME_STOP,h.PRODUCT_ID,c.DEPT,c.UPD_TIME as TIME_CONFIRM,c.USER_CONFIRM, 
case when c.RESULT_CONFIRM = 0 then 'NG'
	when c.RESULT_CONFIRM = 1 then 'OK'
	end as RESULT,
	h.IS_DM_ACCEPT,
	h.MACHINE_SLOT
 from Tokusai_LineHistory as h 
 left join Tokusai_LineConfirm as c on h.ID = c.ID_HISTORY 
 where 
	(@IsOnline = 1 and @IsECO = 0 and h.WO not in (select ORDER_NO from ECO_WoChanging))
	or (@IsECO = 1 and @IsOnline = 0 and h.WO in (select ORDER_NO from ECO_WoChanging))
	or (@IsECO = 1 and @IsOnline = 1)
	
 ORDER bY TIME_STOP DESC
END


GO
/****** Object:  StoredProcedure [dbo].[Tokusai_GetAllLineConfirmCompletedByDate]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tokusai_GetAllLineConfirmCompletedByDate]
	-- Add the parameters for the stored procedure here
	 (
         @IsOnline  bit,
		 @IsECO  bit,
		 @From date,
		 @To date
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select  CONVERT(varchar(36), h.ID) as ID,h.LINE_ID,h.PART_ID,h.WO,h.CHANGE_NAME,h.UPD_TIME as TIME_STOP,h.PRODUCT_ID,c.DEPT,c.UPD_TIME as TIME_CONFIRM,c.USER_CONFIRM, 
case when c.RESULT_CONFIRM = 0 then 'NG'
	when c.RESULT_CONFIRM = 1 then 'OK'
	end as RESULT,
	h.IS_DM_ACCEPT,
	h.MACHINE_SLOT
 from Tokusai_LineHistory as h 
 left join Tokusai_LineConfirm as c on h.ID = c.ID_HISTORY 

 where 
	h.UPD_TIME >= @From and h.UPD_TIME <= @To
	and(
	(@IsOnline = 1 and @IsECO = 0 and h.WO not in (select ORDER_NO from ECO_WoChanging))
	or (@IsECO = 1 and @IsOnline = 0 and h.WO in (select ORDER_NO from ECO_WoChanging))
	or (@IsECO = 1 and @IsOnline = 1)
	)
	
 ORDER bY TIME_STOP DESC
END


GO
/****** Object:  StoredProcedure [dbo].[Tokusai_GetLineStop]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Tokusai_GetLineStop]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
END

GO
/****** Object:  StoredProcedure [dbo].[Tokusai_LineItem_Update]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create PROC [dbo].[Tokusai_LineItem_Update]
                            (
                                @Data AS [dbo].[udt_Tokusai_LineItem] READONLY
                            )
                            AS
                            BEGIN
                                MERGE [dbo].[Tokusai_LineItem] AS [Target]
                                USING @Data AS [Source]
                                ON [Source].[LINE_ID] = [Target].[LINE_ID]
									and [Source].PART_ID = [Target].PART_ID
									and [Source].PRODUCT_ID = [Target].PRODUCT_ID
                                -- For Inserts
                                WHEN NOT MATCHED BY target THEN

							
                                    INSERT
                                    (
										LINE_ID,
										PART_ID,
										PRODUCT_ID,
										UPD_TIME,
										WO,
										IS_TOKUSAI,
										IS_DM_ACCEPT,
										MATERIAL_ORDER_ID
									)
                                    VALUES
                                    (
										[Source].[LINE_ID],
										[Source].PART_ID,
										[Source].PRODUCT_ID,
										[Source].UPD_TIME,
										[Source].WO,
										[Source].IS_TOKUSAI,
										[Source].IS_DM_ACCEPT,
										[Source].MATERIAL_ORDER_ID
								     )
									 
                                -- For Updates
                                WHEN MATCHED THEN
									   UPDATE SET 
										[Target].UPD_TIME = [Source].UPD_TIME,
										[Target].IS_TOKUSAI = [Source].IS_TOKUSAI,
										[Target].IS_DM_ACCEPT = [Source].IS_DM_ACCEPT;
										
										
                            END;


GO
/****** Object:  Trigger [dbo].[insert_mainsub_trigger]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[insert_mainsub_trigger]
   ON [dbo].[MainSub_LineItem]
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @ID UNIQUEIDENTIFIER
	SET @ID = NEWID();

	DECLARE @ALTER_PART_ID nvarchar(64),@PART_ID nvarchar(64)
	select @ALTER_PART_ID = ALTER_PART_ID from inserted 
	select @PART_ID = PART_ID from inserted 
	if @ALTER_PART_ID <> '' and @ALTER_PART_ID <> @PART_ID

		begin
			 insert into Tokusai_LineHistory (ID,LINE_ID,PART_ID,PRODUCT_ID,UPD_TIME,CHANGE_NAME,CHANGE_ID,WO,IS_DM_ACCEPT,MATERIAL_ORDER_ID)
				select @ID, inserted.LINE_ID,inserted.PART_ID,inserted.PRODUCT_ID,inserted.UPD_TIME, 
			CHANGE_NAME = 'MainSub('+inserted.PART_ID+'->'+inserted.ALTER_PART_ID+')',
			CHANGE_ID = 5,
			inserted.WO,
			IS_DM_ACCEPT = 1,
			inserted.MATERIAL_ORDER_ID
			from inserted 
			 
		end 

END

GO
/****** Object:  Trigger [dbo].[update_mainsub_trigger]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[update_mainsub_trigger]
   ON [dbo].[MainSub_LineItem]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @ID UNIQUEIDENTIFIER
	SET @ID = NEWID();

	DECLARE @OLD_ALTER_PART_ID  nvarchar(64),@NEW_ALTER_PART_ID nvarchar(64)
	select @NEW_ALTER_PART_ID = ALTER_PART_ID from inserted 
	select @OLD_ALTER_PART_ID = ALTER_PART_ID from deleted
	 
	if @OLD_ALTER_PART_ID != @NEW_ALTER_PART_ID and @NEW_ALTER_PART_ID <> ''
		begin
			 insert into Tokusai_LineHistory (ID,LINE_ID,PART_ID,PRODUCT_ID,UPD_TIME,CHANGE_NAME,CHANGE_ID,WO,IS_DM_ACCEPT,MATERIAL_ORDER_ID)
				select @ID, inserted.LINE_ID,inserted.PART_ID,inserted.PRODUCT_ID,inserted.UPD_TIME, 
			CHANGE_NAME = 'MainSub('+inserted.PART_ID+'->'+inserted.ALTER_PART_ID+')',
			CHANGE_ID = 3,
			inserted.WO,
			IS_DM_ACCEPT = 1,
			inserted.MATERIAL_ORDER_ID
			
			from inserted 
			 insert into MainSub_LineItem_backup select * from deleted
		end 
   

END

GO
/****** Object:  Trigger [dbo].[LineConfirm_trigger]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[LineConfirm_trigger]			
   ON  [dbo].[Tokusai_LineConfirm]			
   AFTER INSERT			
AS 			
BEGIN			
		
	SET NOCOUNT ON;		
			
    -- Insert statements for trigger here			
	declare @numberConfirm    INT 		
	declare @ID_HISTORY uniqueidentifier		
	select @ID_HISTORY = ID_HISTORY from inserted		
	select @numberConfirm = Count(DEPT) from Tokusai_LineConfirm where ID_HISTORY = @ID_HISTORY		
			
	if @numberConfirm = 3		
		begin	
			update Tokusai_LineHistory set IS_CONFIRM = 1 where ID = @ID_HISTORY 
		end	
			
			
END

GO
/****** Object:  Trigger [dbo].[insert_mainsub]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create TRIGGER [dbo].[insert_mainsub]
   ON  [dbo].[Tokusai_LineHistory]
   AFTER insert
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	DECLARE @CHANGE_ID nvarchar(50),@ID nvarchar(50)
	select @CHANGE_ID = CHANGE_ID,@ID = ID from inserted 
	if @CHANGE_ID in (3,4,5)
		begin
			insert into Tokusai_LineConfirm(DEPT,UPD_TIME,USER_CONFIRM,RESULT_CONFIRM,ID_HISTORY) values('QA',GETDATE(),'34811',1,@ID)
		end
END

GO
/****** Object:  Trigger [dbo].[update_eco_trigger]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[update_eco_trigger]
   ON [dbo].[Tokusai_LineItem]
   AFTER UPDATE,INSERT
AS 
BEGIN
	
	DECLARE @ID UNIQUEIDENTIFIER
	SET @ID = NEWID();
	 insert into Tokusai_LineHistory (ID,LINE_ID,PART_ID,PRODUCT_ID,UPD_TIME,CHANGE_NAME,CHANGE_ID,WO,IS_DM_ACCEPT,MATERIAL_ORDER_ID)
    select @ID, inserted.LINE_ID,inserted.PART_ID,inserted.PRODUCT_ID,inserted.UPD_TIME,
	 CHANGE_NAME = 'ECO',
	CHANGE_ID = 2,
	inserted.WO,
	inserted.IS_DM_ACCEPT,
	inserted.MATERIAL_ORDER_ID
	
    from inserted  where inserted.WO in (select ORDER_NO from ECO_WoChanging)
END

GO
/****** Object:  Trigger [dbo].[update_trigger]    Script Date: 10/23/2023 10:00:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[update_trigger]
   ON [dbo].[Tokusai_LineItem]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @ID UNIQUEIDENTIFIER
	SET @ID = NEWID();
	DECLARE @OLD_IS_TOKUSAI bit, @NEW_IS_TOKUSAI  nvarchar(64)
	select @NEW_IS_TOKUSAI =  IS_TOKUSAI from inserted 
	select @OLD_IS_TOKUSAI = IS_TOKUSAI from deleted

	if @OLD_IS_TOKUSAI != @NEW_IS_TOKUSAI 
		begin

			insert into Tokusai_LineHistory (ID,LINE_ID,PART_ID,PRODUCT_ID,UPD_TIME,CHANGE_NAME,CHANGE_ID,WO,IS_DM_ACCEPT,MATERIAL_ORDER_ID)
			select @ID, inserted.LINE_ID,inserted.PART_ID,inserted.PRODUCT_ID,inserted.UPD_TIME, 
			case when inserted.IS_TOKUSAI = 1 then N'Tokusai Trắng => Hồng'
				 when inserted.IS_TOKUSAI = 0 then N'Tokusai Hồng => Trắng'
			end as CHANGE_NAME,
			CHANGE_ID = inserted.IS_TOKUSAI,
			inserted.WO,
			inserted.IS_DM_ACCEPT,
			inserted.MATERIAL_ORDER_ID
			from inserted 

			insert into Tokusai_LineItem_backup select * from deleted
		end
	
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0.Hồng-> Trắng. 1. Trắng-> Hồng.2.ECO.3.MainSub update alterpart.4.MainSub khi change part .5.MainSub insert alter part.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tokusai_LineHistory', @level2type=N'COLUMN',@level2name=N'CHANGE_ID'
GO
