   M S B A M L   `   `   `  ����  UI    UI.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � RowDefinitions 5	   
   �� 5
      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6    �� SelectedItem 6"   �� *SelectedTabItem+.@�5      �� -   5        $��MovieTab��5      ��5      �� 5      $��Movie��6     � ContextMenu 5      �� 5      .@�5      m� $��Удалить��6#    m� Command 64   �� *
DeleteItem+5      .��5      �� -   5         ��Name$ ViewAllMovies��5      ��62   �� *
AllMovie+ 6S   �� *SelectedMovie+ �� View 5      �� 5      .P�5      �� $��Title��6-    �� DisplayMemberBinding 5   -   ��  �� Path$ Title��� 5      $
��Cost��6-    5   -   �� $
 Cost��� 5      $
��Type��6-    5   -   �� $ MovieTypeTitle�5       5"      5#      �� 5$      -   5        $��UsersTab��5$      ��5%      �� 5&      $
��User��6     5(      �� 5)      .@�5*      m� $��Удалить��6#    64   �� *
DeleteItem+5+      .��5-      �� -   5        $ ViewAllUsers��5-      ��61   �� *	AllUser+ 6Q   �� *SelectedUser+ 5.      �� 5/      .P�50      �� $��Login��6-    51   -   �� $ Login��� 52      $��Password��6-    53   -   �� $ Password��� 54      $
��Role��6-    55   -   �� $
 Role�56      58      59      �� 5:      -   5        $��MovieTypeTab��5:      ��5;      �� 5<      $
��Type��6     5>      �� 5?      .@�5@      m� $��Удалить��6#    64   �� *
DeleteItem+5A      .��5C      �� -   5        $ ViewAllMovieTypes��5C      ��66   �� *AllMovieType+ 6[   �� *SelectedMovieType+ 5D      �� 5E      .P�5F      �� $��Title��6-    5G   .   �� $ Title�5H      5J      5K      5L      �� 5M   
   $��1��6   	 �� Orientation$	 
Horizontal=�6"   $��Right=�5N      .+�5O      �� $��	New Movie��6   ��6)   �� *AddNewMovieWnd+�� 5P      $��
Find Movie��6   ��6*   �� *FindMovieWnd+�� 5Q      $��New MovieType��6   ��6-   �� *AddNewMovieTypeWnd+�� 5R      $��New User��6   ��6(   �� *AddNewUserWnd+�� 5S      $��	Find User��6   ��6)   �� *FindUserWnd+5T      5U      5V      