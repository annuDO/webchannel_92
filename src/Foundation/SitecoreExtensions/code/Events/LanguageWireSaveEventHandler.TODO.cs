using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.SecurityModel;
using Sitecore.Workflows;
using System;
using Sitecore.Diagnostics;
using Sitecore.Publishing;
using Sitecore.Workflows.Simple;
using Sitecore.Pipelines;
using Sitecore.Diagnostics.PerformanceCounters;
using Sitecore.Collections;

namespace DLBi.Sitecore.Events
{
  //TODO: Integrate Language wire
  //public class LanguageWireSaveEventHandler
  //  {
  //      private string LanguageTransaltedWorkFlowState = global::Sitecore.Configuration.Settings.GetSetting("LanguageTransaltedWorkFlowStateId");

  //      protected void OnItemSaved(object sender, EventArgs args)
  //      {
  //          using (new SecurityDisabler())
  //          {
  //              Log.Info("LanguageTransaltedWorkFlow Started",this);

  //            var currentItem = Event.ExtractParameter(args, 0) as Item;

  //              if (currentItem == null)
  //                  return;

  //              var contextDatabase = Factory.GetDatabase("master");
  //              if (contextDatabase == null)
  //                  return;

  //              currentItem = contextDatabase.GetItem(currentItem.ID, currentItem.Language, currentItem.Version);

  //              if (currentItem == null || (global::Sitecore.Context.Site != null
  //                  && global::Sitecore.Context.Site.Name != "shell") || PublishHelper.IsPublishing()) return;


  //              try
  //              {
  //                  using (new EditContext(currentItem, SecurityCheck.Disable))
  //                  {                       
  //                      IWorkflow workflow = Factory.GetDatabase("master")?.WorkflowProvider.GetWorkflow(currentItem);

  //                      if (workflow == null) return;

  //                      if (!string.IsNullOrEmpty(currentItem[global::Sitecore.FieldIDs.Workflow]) && 
  //                          !string.IsNullOrEmpty(currentItem[global::Sitecore.FieldIDs.WorkflowState]))
		//				{
		//					if(!string.IsNullOrWhiteSpace(LanguageTransaltedWorkFlowState) &&
  //                              currentItem[global::Sitecore.FieldIDs.WorkflowState].Equals(LanguageTransaltedWorkFlowState))
  //                          {                                
  //                              Item stateItem = currentItem.Database.GetItem(LanguageTransaltedWorkFlowState);

  //                              if (stateItem.HasChildren)
  //                              {
  //                                 WorkflowPipelineArgs workflowPipelineArgs = new WorkflowPipelineArgs(currentItem, new StringDictionary
  //                                                                                          {
  //                                                                                              {
  //                                                                                                  "Comments",
  //                                                                                                  "Language Translated"
  //                                                                                              }
  //                                                                                          }, new object[0]);

  //                                  Pipeline pipeline = Pipeline.Start(stateItem, workflowPipelineArgs);
  //                                  if (pipeline != null)
  //                                  {
  //                                      DataCount.WorkflowActionsExecuted.IncrementBy(pipeline.Processors.Count);
  //                                  }
  //                              }
  //                          }							
								 
		//				}
  //                  }
  //              }
  //              catch (Exception ex)
  //              {
  //                  Log.Error("Error on creating item (LanguageTransaltedWorkFlow):" + currentItem.ID + Environment.NewLine + "StackTrace:" + ex.StackTrace, ex);
  //              }
  //          }
  //      }
  //  }
}