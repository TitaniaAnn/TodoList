   M S B A M L   `   `   `  ����C  ?TodoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TodoList.ControlsTodoList.Controls  5   	   #clr-namespace:TodoListTodoList  5   	   /clr-namespace:TodoList.ViewsTodoList.Views  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 64       TodoList.MainWindow   5   	   ,Controlsclr-namespace:TodoList.Controls  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TodoList     5   	   .Viewsclr-namespace:TodoList.Views     5   	   9System&clr-namespace:System;assembly=mscorlib     64     � Title$  	Todo List��5	   	    � 	Resources 5
         BrushHeaderBackgroundColor �� Color  BrushHeaderTextColor  BrushMainBackgroundColor  sbShowTaskMenu �� TargetProperty t� From	 t� To g� DecelerationRatio g� Duration  sbHideTaskMenu g� AccelerationRatio  AllTasksCount��%�  &	        &	 #     &	 F     &	 i     &	 �     &	 m    �� 5   
   $ 	#FF0A5663��6a   �� 5   
   $ 	#FFFFFCDE��6U   �� 5   
   $ 	#FFF5F3DD��6]   �� 5   
   .��5      t� $ Margin�6!   $ 
-250,0,0,0X�6D   $ 0,0,0,0X�6V   $ .9Q�6c   $ 0:0:1D�6z   5      �� 5   
   .��5      t� $ Margin�6!   $ 0,0,0,0X�6D   $ 
-250,0,0,0X�6S   $ .9Q�6c   $ 0:0:1D�6z   5      ��5   
   0��61   5      .��5      � .+�5   
   ]� .+�5      ]� -   5        	 ]�Name$	 HeaderPanel��5      $��50��6-   $	��Top=�69   #���   6N   .+�5      6   0TodoList.Controls.MenuButtonThreeBarsUserControl  -   5        
  Name$
 btnShowHideTaskMenu��5   :   6   0TodoList.Controls.MenuButtonThreeBarsUserControl   Loaded$+ %MenuButtonThreeBarsUserControl_Loaded��6W   �� 5      -   5         ��Name$ lblCurrentPanel��5      $��	All Tasks��61   $
��Left=�6E   $��Center=�6`   $��Microsoft Sans Serif)�6{   $��16(�6�   $
��Bold"�6�   ���	#FFFFFCDE$
��0,11q�6�   5      ]� 5      -   5        $	 TaskListViewPanel��5      $	��250��63   $��
-250,0,0,0q�6?   #���  6S   .+�5      )   #TodoList.Controls.ButtonUserControl  -   5          Name$ 
btnAllTask��5   -   )   #TodoList.Controls.ButtonUserControl   Loaded$ btnAllTask_Loaded��6A   $��Stretch=�6\   $	��Top=�6z   $��50��6�     5      -   5        $ btnTodayTask��5   -   $ btnTodayTask_Loaded��6C   $��Stretch=�6`   $	��Top=�6~   $��50��6�     5      -   5        $ btnWeekTask��5   -   $ btnWeekTask_Loaded��6B   $��Stretch=�6^   $	��Top=�6|   $��50��6�   �� 5       $	��0,5q�6   $	��Top=�6)   ]� 5"      $��Bottom=�6   .+�5#      �� $
��User��6   �� 5$      $��Settings��6   $��Right=�6/   5%      �� 5&      $	��0,5q�6   $��Bottom=�6)   !   TodoList.Views.TaskListView  5'      -   5          Name$ TaskListViewControl��5'   %   !   TodoList.Views.TaskListView   Loaded$  TaskListViewControl_Loaded��6B   $	��Top=�6f   5(      �� 5*      -	   5         ��Name$ pnlMain��5*       �� Orientation$ Vertical=�6*   $��Stretch=�6A   $��Right=�6_   .+�5F         TodoList.Views.TaskView  -
   5          Name$ TaskViewControl��5F   !      TodoList.Views.TaskView   Loaded$ TaskViewControl_Loaded��6:   5G      5H      �� 5I   
   $	��200��6   $��
0,0,-200,0q�6!   $��Right=�65   ���	#FFF5F3DD K� ZIndex$ 2��6h   .+�5J      � $��50��6   ���	#FF0A5663.+�5K      �� -   5        $ lblTitleEdit��5K      $
��Edit��6.   $
��Left=�6=   $��Center=�6X   $��Microsoft Sans Serif)�6s   $��16(�6�   $
��Bold"�6�   ���	#FFFFFCDE6�   �� 5L      $��Right=�6   $ 
Horizontal=�69   .+�5M      �� -   5         ��Name$ btnEditTaskCancel��5M      ��68   Z� ��6N   Z� .��5N      �� $ 
Horizontal=�6%   .+�5O      �� $��X��6$   ���	#FFFFFCDE$
��Bold"�6G   $��Microsoft Sans Serif)�6Z   �� 5P      $��Cancel��6$   ���	#FFFFFCDE$
��Bold"�6L   $��Microsoft Sans Serif)�6_   5Q      5R      �� 5S      -   5        $ btnEditTaskSave��5S      ��66   Z� ��6L   Z� .��5T      �� $ 
Horizontal=�6%   .+�5U      �� $��*��6$   ���	#FFFFFCDE$
��Bold"�6G   $��Microsoft Sans Serif)�6Z   �� 5V      $
��Save��6$   ���	#FFFFFCDE$
��Bold"�6J   $��Microsoft Sans Serif)�6]   5W      5X      5Y      5Z      5[      5_      5`      