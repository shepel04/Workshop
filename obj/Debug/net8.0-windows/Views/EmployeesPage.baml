   M S B A M L   `   `   `  ����C  ?Workshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Workshop.ViewsWorkshop.Views  5      "    Workshop.Views.EmployeesPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Workshop.Views     5        N� Title$  EmployeesPage��5	       N� 
Foreground
 �����.��5      � .+�5   
   �� $ ��Співробітники��6   $
��Left=�6(   $��48��6C   $��	10,10,0,0q�6O   $	��Top=�6b   $	��262��6z   $��22(�6�   
�������$��Arial Black)�6�   $
��Bold"�6�   $��2��6�   $��2��6�   �� 5   
   $��Right=�6   $	��Top=�61    �� Orientation$ 
Horizontal=�6I   $��15q�6b   .+�5      �� -   5         ��Name$ EmployeeSearchTextBox��5      $��0��65   $��1��6B   $	��Top=�6R   $��20��6j   $��0q�6v   $��Right=�6�   $	��100��6�   6�   �� 5      -   5         ��Name$ FindEmployeeButton��5      $��2��61   $��
Пошук��6A   $��Center=�6Q   $��20��6n   $��10,0,0,0q�6z   $��0��6�   $	��Top=�6�   $��60��6�   6�   �� 5      -   5        $ RefreshEmployeeButton��5      $��2��64   $��Оновити��6D   $��Center=�6V   $��20��6s   $��10,0,0,0q�6   $��0��6�   $	��Top=�6�   $��60��6�   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ EmployeesDataGrid��5      $��0��6.   $��10,63,10,136q�6>   $
��Auto��6T      AutoGenerateColumns$
 True��6a   $ �� IsSynchronizedWithCurrentItem$ FalseY�6|   
���   �
���   �6�   �� 5   
   $
��Left=�6   $��Bottom=�60   $ 
Horizontal=�6K   $��15q�6d   .+�5      �� -   5        $ AddEmployeeButton��5      $��+��60   $
��Left=�6<   $��45��6W   $��0,0,0,0q�6c   $��Bottom=�6t   $��45��6�   $��Arial Black)�6�   $��24(�6�   6�   �� 5      -   5        $ DeleteEmployeeButton��5      $��Видалити��63   $
��Left=�6F   $��45��6a   $��Bottom=�6m   $��66��6�   $��10,0,0,0q�6�   5      5      5      