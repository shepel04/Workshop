   M S B A M L   `   `   `  ����C  ?Workshop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Workshop.ViewsWorkshop.Views  5   	   '    !Workshop.Views.AddToStorageWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Workshop.Views     5   	     � Title$"  Додати на склад��5   	   $	��314��6!   $	��291��6.   .��5	      � $��0,0,0,0q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��10q�6   .+�5      �� $��0��6   $��Name:��6!   �� 5      -   5         ��Name$ productNameTextBox��5   #   $��1��6   6#   �� 5      $��1��6   $��Description:��6!   �� 5      -   5        $ productDescriptionTextBox��5   #   $��1��6   6#   �� 5      $��2��6   $��Price:��6!   �� 5       -   5        $ productPriceTextBox��5    #   $��2��6   6#   �� 5"      $��3��6   $��	Category:��6!   �� 5#      -   5        $ productCategoryTextBox��5#   #   $��3��6   6#   �� 5%      $��4��6   $��Quantity in Stock:��6!   �� 5&      -   5        $ productQuantityTextBox��5&   #   $��4��6   6#   �� 5(      -   5        $��5��5(      $��Add Product��6"   68   5)      5+      5,      