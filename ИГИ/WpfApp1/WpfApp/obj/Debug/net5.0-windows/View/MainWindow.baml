   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfApp.ViewWpfApp.View  5   	       WpfApp.View.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfApp.View     5   	     � Title$  
Start page��5      $	��450��6   $	��800��6"   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��0��6    �� SelectedItem 6"   �� *SelectedTabItem+.@�5      �� -   5        $��MovieTab��5      ��5      �� 5      $��Movie��6     � ContextMenu 5      �� 5      .@�5      m� $��Удалить��6#    m� Command 64   �� *
DeleteItem+5      .��5      �� -   5         ��Name$ ViewAllMovies��5      ��62   �� *
AllMovie+ 6S   �� *SelectedMovie+ �� View 5      �� 5      .P�5      �� $��Title��6-    �� DisplayMemberBinding 5   -   ��  �� Path$ Title��� 5      $
��Cost��6-    5   -   �� $
 Cost��� 5      $
��Type��6-    5    -   �� $ MovieTypeTitle�5!      5#      5$      �� 5%      -   5        $��UsersTab��5%      ��5&      �� 5'      $
��User��6     5)      �� 5*      .@�5+      m� $��Удалить��6#    64   �� *
DeleteItem+5,      .��5.      �� -   5        $ ViewAllUsers��5.      ��61   �� *	AllUser+ 6Q   �� *SelectedUser+ 5/      �� 50      .P�51      �� $��Login��6-    52   -   �� $ Login��� 53      $��Password��6-    54   -   �� $ Password��� 55      $
��Role��6-    56   -   �� $
 Role�57      59      5:      �� 5;      -   5        $��MovieTypeTab��5;      ��5<      �� 5=      $
��Type��6     5?      �� 5@      .@�5A      m� $��Удалить��6#    64   �� *
DeleteItem+5B      .��5D      �� -   5        $ ViewAllMovieTypes��5D      ��66   �� *AllMovieType+ 6[   �� *SelectedMovieType+ 5E      �� 5F      .P�5G      �� $��Title��6-    5H   .   �� $ Title�5I      5K      5L      5M      �� 5N   
   $��1��6   	 �� Orientation$	 
Horizontal=�6"   $��Right=�5O      .+�5P      �� $��	New Movie��6   ��6)   �� *AddNewMovieWnd+�� 5Q      $��
Find Movie��6   ��6*   �� *FindMovieWnd+�� 5R      $��New MovieType��6   ��6-   �� *AddNewMovieTypeWnd+�� 5S      $��New User��6   ��6(   �� *AddNewUserWnd+�� 5T      $��	Find User��6   ��6)   �� *FindUserWnd+5U      5V      5W      