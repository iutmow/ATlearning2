using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects;

namespace atFrameWork2.PageObjects
{
    public class TasksListPage
    {
        internal TaskCreationSlider AddTaskBtn()
        {
            //клик в Добавить задачу
            var btnAddTask = new WebItem("//a[@id='tasks-buttonAdd']", "Кнопка Добавить задачу");
            btnAddTask.Click();
            var sliderFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм слайдера");
            sliderFrame.SwitchToFrame();
            return new TaskCreationSlider();
        }

        internal TaskCreationSlider OpenCreatedTask(Bitrix24Task task)
        {
            var openCreatedTask = new WebItem($"//a[contains(text(), '{task.Title}') and contains(@class, 'task-title')]",
                $"Ссылка на задачу '{task.Title}' в гриде");
            openCreatedTask.WaitElementDisplayed();
            openCreatedTask.Click();
            var sliderFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм слайдера");
            sliderFrame.SwitchToFrame();
            return new TaskCreationSlider();
        }

    }

}