using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class TaskCreationSlider
    {
        internal TaskCreationSlider GiveNameToTask(Bitrix24Task task)
        {

            //ввести название задачи
            var giveNameToTask = new WebItem("//input[@data-bx-id='task-edit-title']", "Текстбокс названия задачи");
            giveNameToTask.WaitElementDisplayed();
            giveNameToTask.SendKeys(task.Title);
            return new TaskCreationSlider();
        }

        internal TaskCreationSlider GiveDescriptionToTask(Bitrix24Task task)
        {
            //ввести описание задачи
            var editorFrame = new WebItem("//iframe[@class='bx-editor-iframe']", "Фрейм редактора текста");
            editorFrame.SwitchToFrame();
            var giveDescriptionToTask = new WebItem("//body[@contenteditable='true']", "Текстбокс описания задачи");
            giveDescriptionToTask.SendKeys(task.Description);
            return new TaskCreationSlider();
        }

        internal TasksListPage SetTask()
        {
            //клик в Поставить задачу
            DriverActions.SwitchToDefaultContent();
            var sliderFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм слайдера");
            sliderFrame.SwitchToFrame();
            var btnSetTask = new WebItem("//button[@data-bx-id='task-edit-submit' and @class='ui-btn ui-btn-success']", "Кнопка Поставить задачу");
            btnSetTask.WaitElementDisplayed();
            btnSetTask.Click();
            DriverActions.SwitchToDefaultContent();
            return new TasksListPage();

        }

        internal TaskCreationSlider AddComment(string commentText)
        {
            //добавить комментарий

            var openCommentBox = new WebItem("//a[@class='feed-com-add-link']", "поле коммента");
            openCommentBox.Click();
            var commentFrame = new WebItem("//iframe[@class='bx-editor-iframe']", "фрейм коммента");
            commentFrame.SwitchToFrame();
            var addComment = new WebItem("//body[@contenteditable='true']", "текстбокс комментария к задаче");
            addComment.SendKeys(commentText);
            var btnSendComment = new WebItem("//button[contains(@id, 'submit_COMMENTS')]", "кнопка отправить коммент");
            DriverActions.SwitchToDefaultContent();
            var sliderFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм слайдера");
            sliderFrame.SwitchToFrame();
            btnSendComment.Click();
            return new TaskCreationSlider();

        }

        internal void CheckTask(Bitrix24Task task, string commentText)
        {

            var taskNameCheck = new WebItem("//div[@class='tasks-iframe-header']//span[@id='pagetitle']", "Название задачи");
            if (!taskNameCheck.AssertTextContains(task.Title, "название задачи неверно"))
                Log.Error("Название задачи не совпало с заданным");
            var taskDescriptionCheck = new WebItem("//div[@id='task-detail-description']", "Описание задачи");
            if (!taskDescriptionCheck.AssertTextContains(task.Description, "описание задачи неверно"))
                Log.Error("Описание задачи не совпало с заданным");
            var taskCommentCheck = new WebItem("//div[contains(@id, 'record-TASK') and contains(@class, 'feed-com-text')]/div", "коммент к задаче");
            if (!taskCommentCheck.AssertTextContains(commentText, ""))
                Log.Error("Комментарий не совпал с заданным");

        }

    }
        
}
