   M S B A M L   `   `   `  ����F  BBITServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BITServices.UI.PagesBITServices.UI.Pages  5      /    )BITServices.UI.Pages.JobRequestManagement   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:BITServices.UI.Pages     5      -   5          N� Title$  JobRequestManagement��5	       � 	Resources 5
      )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value ^� 
Conditions	 �� Binding
 �� Value��%S  '        �� 5   
   "  6    5      �� 5       6   �� *	JobStatus+
 Verify6<   .a�5      ��  � ��
 �����63   5      ^� 5       5      �� 5      	 6$   �� *	JobStatus+

 Active6B   �� 5      	 6$   �� *AssignedContractor+
 6K   Z� 0�5      �� 5       � ��
 ��ح�67   5      �� 5       6   �� *	JobStatus+ Rejected6<   .a�5      ��  � ��
 ��ح�63   5      �� 5       6   �� *	JobStatus+ 	Completed6<   .a�5      ��  � ��
 ����63   5      5       5!      .��5"      � $��20q�6   .+�5#   
   ]� ��.  .+�5(      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgrRecords��5(      $��0,5,5,5q�6+   $	��Top=�6<   $	��425��6Q      
IsReadOnly . ��6^   �� *JobCollection+ �� SelectedItem 6�   �� *SelectedJob+ � ContextMenu 5)      �� 5*      .@�5+      m� $��Hide Completed Jobs��6#    m� IsCheckable . 6@   5,      5.      � 5/      $��Bottom=�6   $��Right=�60   .+�50      �� -   5         ��Name$ btnCreateRequest��50      $��Create Request��63   $��5q�6L   $��0,0,5,0q�6X   6i   �� 51      -   5        $ btnEditRequest��51      $��Edit Request��61   $��5q�6H   $��0,0,5,0q�6T   6e   �� 52      -   5        $ btnVerifyRequest��52      $��Verify Request��63   $��5q�6L   $��0,0,5,0q�6X   ��6i   �� *VerifyRequestCommand+�� 53      -   5        $ btnDeleteRequest��53      $��Delete Request��63   $��5q�6L   ��6X   �� *DeleteRequestCommand+54      55      56      57      