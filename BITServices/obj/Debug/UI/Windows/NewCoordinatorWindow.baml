   M S B A M L   `   `   `  ����F  BBITServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:BITServices.UI.WindowsBITServices.UI.Windows  5   	   I)clr-namespace:BITServices.UI.UserControlsBITServices.UI.UserControls  5   	   1    +BITServices.UI.Windows.NewCoordinatorWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:BITServices.UI.Windows     5   	   8uc)clr-namespace:BITServices.UI.UserControls     5   	     � Title$  New Coordinator��5	   	   $	��575��6!   $	��350��6.    � Icon$" ..\Images/Logo/LogoSmall.png��6:    � 
ResizeMode$ NoResize=�6^   .��5
      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Profile Picture:��6   $��0��6+   $��0��68   $��Right=�6H   $��Center=�6d   ,   &BITServices.UI.UserControls.ProfilePic  5    
   -   5          Name$ ucProfilePic��5       $��0��6.   $��1��6;   $��Right=�6K   $��0,0,5,5q�6�      ProfilePicImagePath 6g   �� *CoordinatorImagePath+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5!   
   $��First Name:��6   $��1��6&   $��0��63   $��Right=�6C   �� 5"   
   -   5        	 ��Name$	 txtFirstName��5"      $��1��6(   $��1��65      textboxPadding#��[  6E   ��6m   �� *NewCoordinator.FirstName+$ PropertyChanged=�$ TwoWay=�
 �� ValidatesOnExceptions
 . �� 5#   
   $��
Last Name:��6   $��2��6%   $��0��62   $��Right=�6B   �� 5$   
   -   5        $	 txtLastName��5$      $��2��6'   $��1��64   #��[  6D   ��6l   �� *NewCoordinator.LastName+$ PropertyChanged=�$ TwoWay=�
 . �� 5%   
   $��Street:��6   $��3��6"   $��0��6/   $��Right=�6?   �� 5&   
   -   5        $	 	txtStreet��5&      $��3��6%   $��1��62   #��[  6B   ��6j   �� *NewCoordinator.Street+$ PropertyChanged=�$ TwoWay=�
 . �� 5'   
   $��Suburb:��6   $��4��6"   $��0��6/   $��Right=�6?   �� 5(   
   -   5        $	 	txtSuburb��5(      $��4��6%   $��1��62   #��[  6B   ��6j   �� *NewCoordinator.Suburb+$ PropertyChanged=�$ TwoWay=�
 . �� 5)   
   $��State:��6   $��5��6!   $��0��6.   $��Right=�6>   �� 5*   
   -   5         ��Name$ cmbState��5*      $��5��6%   $��1��62   $	��0,5q�6B   $��23��6O    �� SelectedValuePath$ Content��6�    �� SelectedValue 6[   �� *NewCoordinator.State+$ PropertyChanged=�$ TwoWay=�
 . .@�5+      �� $	��NSW��6   �� 5,      $	��QLD��6   �� 5-      $��NT��6   �� 5.      $��WA��6   �� 5/      $��SA��6   �� 50      $	��VIC��6   �� 51      $	��TAS��6   �� 52      $	��ACT��6   54      �� 55   
   $��
Post Code:��6   $��6��6%   $��0��62   $��Right=�6B   �� 56   
   -   5        $	 txtPostCode��56      $��6��6'   $��1��64   #��[  6D   ��6l   �� *NewCoordinator.PostCode+$ PropertyChanged=�$ TwoWay=�
 . �� 57   
   $��Email:��6   $��7��6!   $��0��6.   $��Right=�6>   �� 58   
   -   5        $	 txtEmail��58      $��7��6$   $��1��61   #��[  6A   ��6i   �� *NewCoordinator.Email+$ PropertyChanged=�$ TwoWay=�
 . �� 59   
   $��Phone Number:��6   $��8��6(   $��0��65   $��Right=�6E   �� 5:   
   -	   5        $	 txtPhone��5:      $��8��6$   $��1��61   #��[  6A   ��6i   �� *NewCoordinator.PhoneNumber+$ PropertyChanged=�$ TwoWay=�
 . �� 5;   
   $��Mobile Number:��6   $��9��6)   $��0��66   $��Right=�6F   �� 5<   
   -
   5        $	 	txtMobile��5<      $��9��6%   $��1��62   #��[  6B   ��6j   �� *NewCoordinator.MobileNumber+$ PropertyChanged=�$ TwoWay=�
 . �� 5=   
   $��	Username:��6   $��10��6$   $��0��62   $��Right=�6B   �� 5>   
   -   5        $	 txtUsername��5>      $��10��6'   $��1��65   #��[  6E   ��6m   �� *NewCoordinator.Username+$ PropertyChanged=�$ TwoWay=�
 . �� 5?   
   $��	Password:��6   $��11��6$   $��0��62   $��Right=�6B   G� 5@   
   -   5         G�Name$ pswPassword��5@      $��11��6+   $��1��69   $	��0,5q�6J   $��23��6W   6c   �� 5A   
   $��Password Check:��6   $��12��6*   $��0��68   $��Right=�6H   G� 5B   
   -   5        $ pswCheck��5B      $��12��6(   $��1��66   $	��0,5q�6G   $��23��6T   6`   � 5C   
   $��Bottom=�6   $��Right=�6,   $��1��6H   $��13��6X   $��0,10,0,0q�6f   .+�5D      �� -   5         ��Name$ 	btnCreate��5D      $��Create Coordinator��6(   $��5q�6E   $��0,0,5,0q�6Q   ��6b   �� *NewCoordinatorButtonCommand+�� 5E      -   5        $ 	btnCancel��5E      $��Cancel��6(   $��5q�69   6E   5F      5G      5H      