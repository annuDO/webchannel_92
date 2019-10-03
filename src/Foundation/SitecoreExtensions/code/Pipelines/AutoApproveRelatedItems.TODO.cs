using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.SecurityModel;
using Sitecore.Workflows;
using Sitecore.Workflows.Simple;


namespace Trelleborg.Utilities.Pipelines.Workflows
{
  //TODO: Modify based on new sitecore version
    //public class AutoApproveRelatedItems
    //{

    //    private ID formTemplateID = ID.Parse("FFB1DA32-2764-47DB-83B0-95B843546A7E");

    //    public void Process(WorkflowPipelineArgs args)
    //    {
    //        Assert.ArgumentNotNull(args, "args");
    //        if (args.DataItem == null) { return; }

    //        using (new SecurityDisabler())
    //        {
    //            if (args.ProcessorItem.InnerItem["Parameters"] != null && args.ProcessorItem.InnerItem["Parameters"].ToLower().Contains("publish=1"))
    //            {
    //                // Publish current item. Page or component
    //                var publishAction = new PublishAction();
    //                publishAction.Process(args);                    
    //            }

    //            using (new LanguageSwitcher(args.DataItem.Language))
    //            {
    //                foreach (var pageComponent in GetSubComponents(args.DataItem))
    //                {
    //                    HandleWorkflow(args, pageComponent);
    //                }
    //            }
    //        }
    //    }

    //    public HashSet<Item> GetSubComponents(Item pageItem) {
    //        HashSet<Item> components = new HashSet<Item>();
    //        var validLinks = pageItem.Links.GetValidLinks(false);

    //        foreach (Item reference in validLinks.Select(il => il.GetTargetItem()))
    //        {
    //            if (reference.Paths.IsContentItem || reference.Paths.IsMediaItem)
    //            {
    //                //Remove items that is not in the item database
    //                if (reference.Database.Name == pageItem.Database.Name) {
    //                    components.Add(reference);
    //                }
    //            } else if (reference.TemplateID == formTemplateID) {
    //                // Forms from WFFM are special. Here we find and handle them. 
    //                // We just add the form-item plus all its sub-items. 
    //                components.Add(reference);
    //                string escapedPath = reference.Paths.FullPath.Replace("/", "#/#").Substring(1) + "#"; // escape every path item
    //                string fastQuery = string.Format("fast:{0}//*", escapedPath);
    //                Item[] items = _database.SelectItems(fastQuery);
    //                foreach (var formItem in items) {
    //                    components.Add(formItem);
    //                }
    //            }
    //        }

    //        return components;
    //    }


    //    private void HandleWorkflow(WorkflowPipelineArgs args, Item subComponent)
    //    {
    //        WorkflowState currentWorkflowState = GetWorkflowStateForItem(subComponent);
    //        if (currentWorkflowState != null)
    //        {

    //            // We get the new workflow state from the item that the action ('approve' or 'approve and publish') was performed on. 
    //            WorkflowState newWorkflowState = GetWorkflowStateForItem(args.DataItem);
    //            UpdateWorkflow(newWorkflowState, currentWorkflowState, subComponent);
    //        }
    //    }
        

    //    public bool UpdateWorkflow(WorkflowState newWorkflowState, WorkflowState currentWorkflowState, Item item)
    //    {
    //        Assert.ArgumentNotNull(item, "Item can not be null");
    //        Assert.ArgumentNotNull(newWorkflowState, "The new WorkflowState can not be null");

    //        bool successful = false;

    //        if (currentWorkflowState != newWorkflowState)
    //        {
    //            IWorkflow workflow = GetWorkflowOfItem(item);

    //            if (workflow != null)
    //            {

    //                // Try to set the item into the new workflow state. 
    //                List<WorkflowCommand> applicableWorkflowCommands = workflow.GetCommands(currentWorkflowState.StateID).ToList();

    //                foreach (var applicableWorkflowCommand in applicableWorkflowCommands)
    //                {
    //                    Item commandItem = _database.GetItem(applicableWorkflowCommand.CommandID);
    //                    string nextStateId = commandItem["Next state"];

    //                    if (newWorkflowState.StateID == nextStateId) {
    //                        WorkflowResult workflowResult = workflow.Execute(applicableWorkflowCommand.CommandID, item, "", false);
    //                        successful = workflowResult.Succeeded;
    //                        break;
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            successful = true;
    //        }

    //        return successful;
    //    }

    //    public WorkflowState GetWorkflowStateForItem(Item item)
    //    {
    //        var workflow = GetWorkflowOfItem(item);
    //        return workflow != null ? workflow.GetState(item) : null;
    //    }

    //    public IWorkflow GetWorkflowOfItem(Item item)
    //    {
    //        return _database.WorkflowProvider.GetWorkflow(item);
    //    }

    //    private Database _database
    //    {
    //        get {
    //            return Database.GetDatabase("master");
    //        }
    //    }


    //    protected virtual void ForceReLockingOfItem(Item item)
    //    {
    //        using (new SecurityDisabler())
    //        {
    //            try
    //            {
    //                item.Editing.BeginEdit();
    //                item.Locking.Unlock();
    //                item.Locking.Lock();
    //                item.Editing.EndEdit();
    //            }
    //            catch (Exception ex)
    //            {
    //                Log.Error(this.ToString(), ex, this);
    //            }
    //        }
    //    }
    //}
}
