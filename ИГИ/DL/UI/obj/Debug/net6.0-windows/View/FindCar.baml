   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5   	       UI.View.FindCar   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UI.View     5   	   -   5        $��
FindCarWnd��5	   	     � Title$  FindCar��5   	   $	��300��6   $	��300��6&   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $��Center=�5      $��Center=�5      $	��200��5      .+�5      �� $
��Cost��6   �� 5      -   5        $��CostCar��5      ��6%   �� *
CostToFind+�� 5      -   5         ��Name$ ViewFindcar��5   #   $��10q�6   ��68   �� *
FindCarCol+ �� View 5      �� 5      .P�5      �� $��Title��6)    �� DisplayMemberBinding 5   -   ��  �� Path$ Title��� 5      $
��Cost��6)    5   -   �� $
 Cost��� 5      $��CarType��6)    5   -   �� $ CarTypeTitle�5      5       5!      �� 5"   
   $��1��6   $��Find Car��6   ��61   �� *	FindCar+��5#      ��  �� ElementName$ 
FindCarWnd��5$      5%      