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
            giveNameToTask.Click();
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
            var sliderFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм слайдера");
            DriverActions.SwitchToDefaultContent();
            sliderFrame.SwitchToFrame();
            return new TaskCreationSlider();
        }

        internal TaskCreationSlider OpenCreatedTask(Bitrix24Task task)
        {
            DriverActions.SwitchToDefaultContent();
            var openCreatedTask = new WebItem($"//a[contains(text(), '{task.Title}') and contains(@class, 'task-title')]",
                $"Ссылка на задачу '{task.Title}' в гриде");
            openCreatedTask.WaitElementDisplayed();
            openCreatedTask.Click();
            return new TaskCreationSlider();
        }

        internal TaskCreationSlider SetTask()
        {
            //клик в Поставить задачу
            var btnSetTask = new WebItem("//button[@data-bx-id='task-edit-submit' and @class='ui-btn ui-btn-success']", "Кнопка Поставить задачу");
            btnSetTask.Click();
            return new TaskCreationSlider();


            //"//button[@data-bx-id='task-edit-submit' and @class='ui-btn ui-btn-success']"
        }

        
    }
        
}
