   M S B A M L   `   `   `  ����I  EProductProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ProductProjectProductProject  5   	       ProductProject.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ProductProject     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   6)   �� 5      $��40 �6   6*   .+�5   
   �� $��0��6    �� SelectedItem 6"   �� *SelectedItem+.@�5      �� -   5        $��Product_Item��5      ��5      �� 5      $��Product��6    61    � ContextMenu 5      �� 5      .@�5      m� $
��Edit��6#    m� Command 61   �� *EditItemWindow+6V   m� 5      $��Delete��6#    63   �� *
DeleteItem+6T   5      .��5      �� -   5        $��ProjectsListView��5      ��63   �� *ProductsList+ 6X   �� *SelectedProduct+ �� View 5      �� 5      .P�5      �� $
��Name��6-    �� Width$
 Auto��6f    �� DisplayMemberBinding 6;   ��  �� Path$
 Name�6u   �� 5      $��Price��6-   $
 Auto��6h    6<   �� $ Price�6w   5      5       5!      �� 5"      -   5        $��	Link_Item��5"      ��5#      �� 5$      $
��Link��6    6.    5&      �� 5'      .@�5(      m� $
��Edit��6#    61   �� *EditItemWindow+6V   m� 5)      $��Delete��6#    63   �� *
DeleteItem+6T   5*      .��5,      �� -   5        $��LinksListView��5,      ��60   �� *	LinksList+ 6R   �� *SelectedLink+ 5-      �� 5.      .P�5/      �� $
��Name��6-   $
 Auto��6v    6;   �� $ LinkProductName.Name�6�   �� 50      $��Amount��6-   $
 Auto��6i    6=   �� $ Count�6x   51      53      54      55      �� 56   
   $��1��6   	 �� Orientation$	 
Horizontal=�6"   $��Center=�6;   .+�57      �� $��Add Product��6   ��6+   �� *OpenAddNewProductWindow+6Y   �� 58      $��Add Link��6   ��6(   �� *OpenAddNewLinkWindow+6S   59      5:      5;      