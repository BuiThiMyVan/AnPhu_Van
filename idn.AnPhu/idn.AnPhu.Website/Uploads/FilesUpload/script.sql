USE [hcc]
GO
/****** Object:  StoredProcedure [dbo].[Users_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_Update]
GO
/****** Object:  StoredProcedure [dbo].[Users_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Users_GetByExtension]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_GetByExtension]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_GetByExtension]
GO
/****** Object:  StoredProcedure [dbo].[Users_GetAllByQueue]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_GetAllByQueue]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_GetAllByQueue]
GO
/****** Object:  StoredProcedure [dbo].[Users_GetAllByOrg]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_GetAllByOrg]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_GetAllByOrg]
GO
/****** Object:  StoredProcedure [dbo].[Users_GetAllByBranchAndHost]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_GetAllByBranchAndHost]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_GetAllByBranchAndHost]
GO
/****** Object:  StoredProcedure [dbo].[Users_GetAllByBranch]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_GetAllByBranch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_GetAllByBranch]
GO
/****** Object:  StoredProcedure [dbo].[Users_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[Users_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Users_Get]
GO
/****** Object:  StoredProcedure [dbo].[UserOutgoingTrunks_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserOutgoingTrunks_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserOutgoingTrunks_Update]
GO
/****** Object:  StoredProcedure [dbo].[UserOutgoingTrunks_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserOutgoingTrunks_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserOutgoingTrunks_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UserOutgoingTrunks_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserOutgoingTrunks_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserOutgoingTrunks_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[UserOutgoingTrunks_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserOutgoingTrunks_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserOutgoingTrunks_Get]
GO
/****** Object:  StoredProcedure [dbo].[UserModules_RemoveByUser]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserModules_RemoveByUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserModules_RemoveByUser]
GO
/****** Object:  StoredProcedure [dbo].[UserModules_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserModules_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserModules_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UserModules_GetActiveAllByUser]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserModules_GetActiveAllByUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserModules_GetActiveAllByUser]
GO
/****** Object:  StoredProcedure [dbo].[UserMessages_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessages_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessages_Update]
GO
/****** Object:  StoredProcedure [dbo].[UserMessages_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessages_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessages_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UserMessages_GetByGroup]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessages_GetByGroup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessages_GetByGroup]
GO
/****** Object:  StoredProcedure [dbo].[UserMessages_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessages_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessages_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[UserMessages_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessages_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessages_Get]
GO
/****** Object:  StoredProcedure [dbo].[UserMessageGroups_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessageGroups_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessageGroups_Update]
GO
/****** Object:  StoredProcedure [dbo].[UserMessageGroups_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessageGroups_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessageGroups_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UserMessageGroups_GetSingleByUser]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessageGroups_GetSingleByUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessageGroups_GetSingleByUser]
GO
/****** Object:  StoredProcedure [dbo].[UserMessageGroups_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessageGroups_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessageGroups_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[UserMessageGroups_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMessageGroups_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserMessageGroups_Get]
GO
/****** Object:  StoredProcedure [dbo].[UserFacebook_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserFacebook_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserFacebook_Update]
GO
/****** Object:  StoredProcedure [dbo].[UserFacebook_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserFacebook_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserFacebook_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UserFacebook_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserFacebook_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserFacebook_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[UserFacebook_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserFacebook_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserFacebook_Get]
GO
/****** Object:  StoredProcedure [dbo].[UserFacebook_Delete]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserFacebook_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserFacebook_Delete]
GO
/****** Object:  StoredProcedure [dbo].[UserEvent_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserEvent_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserEvent_Update]
GO
/****** Object:  StoredProcedure [dbo].[UserEvent_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserEvent_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserEvent_Insert]
GO
/****** Object:  StoredProcedure [dbo].[UserEvent_GetAllUnread]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserEvent_GetAllUnread]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserEvent_GetAllUnread]
GO
/****** Object:  StoredProcedure [dbo].[UserEvent_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserEvent_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserEvent_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[UserEvent_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserEvent_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserEvent_Get]
GO
/****** Object:  StoredProcedure [dbo].[Trunks_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trunks_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Trunks_Update]
GO
/****** Object:  StoredProcedure [dbo].[Trunks_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trunks_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Trunks_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Trunks_GetOutgoingTrunkByExtension]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trunks_GetOutgoingTrunkByExtension]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Trunks_GetOutgoingTrunkByExtension]
GO
/****** Object:  StoredProcedure [dbo].[Trunks_GetAllByBranch]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trunks_GetAllByBranch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Trunks_GetAllByBranch]
GO
/****** Object:  StoredProcedure [dbo].[Trunks_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trunks_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Trunks_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[Trunks_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trunks_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Trunks_Get]
GO
/****** Object:  StoredProcedure [dbo].[Queues_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Queues_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Queues_Update]
GO
/****** Object:  StoredProcedure [dbo].[Queues_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Queues_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Queues_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Queues_GetAllByBranch]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Queues_GetAllByBranch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Queues_GetAllByBranch]
GO
/****** Object:  StoredProcedure [dbo].[Queues_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Queues_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Queues_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[Queues_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Queues_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Queues_Get]
GO
/****** Object:  StoredProcedure [dbo].[Organizations_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organizations_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Organizations_Update]
GO
/****** Object:  StoredProcedure [dbo].[Organizations_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organizations_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Organizations_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Organizations_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organizations_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Organizations_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[Organizations_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organizations_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Organizations_Get]
GO
/****** Object:  StoredProcedure [dbo].[Numbers_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Numbers_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Numbers_Update]
GO
/****** Object:  StoredProcedure [dbo].[Numbers_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Numbers_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Numbers_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Numbers_GetAllByBranch]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Numbers_GetAllByBranch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Numbers_GetAllByBranch]
GO
/****** Object:  StoredProcedure [dbo].[Numbers_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Numbers_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Numbers_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[Numbers_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Numbers_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Numbers_Get]
GO
/****** Object:  StoredProcedure [dbo].[Modules_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modules_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Modules_Update]
GO
/****** Object:  StoredProcedure [dbo].[Modules_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modules_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Modules_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Modules_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modules_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Modules_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[Modules_GetActiveByBranch]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modules_GetActiveByBranch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Modules_GetActiveByBranch]
GO
/****** Object:  StoredProcedure [dbo].[Modules_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modules_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Modules_Get]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatSessions_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatSessions_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatSessions_Update]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatSessions_Search]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatSessions_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatSessions_Search]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatSessions_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatSessions_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatSessions_Insert]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatSessions_GetByAgent]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatSessions_GetByAgent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatSessions_GetByAgent]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatSessions_GetAllByBranch]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatSessions_GetAllByBranch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatSessions_GetAllByBranch]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatSessions_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatSessions_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatSessions_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatSessions_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatSessions_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatSessions_Get]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatMessages_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatMessages_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatMessages_Update]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatMessages_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatMessages_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatMessages_Insert]
GO
/****** Object:  StoredProcedure [dbo].[LiveChatMessages_GetAllBySession]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveChatMessages_GetAllBySession]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LiveChatMessages_GetAllBySession]
GO
/****** Object:  StoredProcedure [dbo].[IVRs_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRs_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRs_Update]
GO
/****** Object:  StoredProcedure [dbo].[IVRs_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRs_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRs_Insert]
GO
/****** Object:  StoredProcedure [dbo].[IVRs_GetAllByBranch]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRs_GetAllByBranch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRs_GetAllByBranch]
GO
/****** Object:  StoredProcedure [dbo].[IVRs_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRs_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRs_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[IVRs_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRs_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRs_Get]
GO
/****** Object:  StoredProcedure [dbo].[IVRItems_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRItems_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRItems_Update]
GO
/****** Object:  StoredProcedure [dbo].[IVRItems_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRItems_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRItems_Insert]
GO
/****** Object:  StoredProcedure [dbo].[IVRItems_GetAllByIVR]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRItems_GetAllByIVR]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRItems_GetAllByIVR]
GO
/****** Object:  StoredProcedure [dbo].[IVRItems_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRItems_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRItems_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[IVRItems_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRItems_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRItems_Get]
GO
/****** Object:  StoredProcedure [dbo].[IVRItems_Delete]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IVRItems_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[IVRItems_Delete]
GO
/****** Object:  StoredProcedure [dbo].[GetAllByBranch]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllByBranch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllByBranch]
GO
/****** Object:  StoredProcedure [dbo].[Facebooks_Update]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Facebooks_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Facebooks_Update]
GO
/****** Object:  StoredProcedure [dbo].[Facebooks_Insert]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Facebooks_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Facebooks_Insert]
GO
/****** Object:  StoredProcedure [dbo].[Facebooks_GetAllByBranch]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Facebooks_GetAllByBranch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Facebooks_GetAllByBranch]
GO
/****** Object:  StoredProcedure [dbo].[Facebooks_GetAll]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Facebooks_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Facebooks_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[Facebooks_Get]    Script Date: 8/12/2020 10:47:26 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[db