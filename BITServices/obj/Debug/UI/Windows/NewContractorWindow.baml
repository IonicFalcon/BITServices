   M S B A M L   `   `   `  ����F  BBITServices, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:BITServices.UI.WindowsBITServices.UI.Windows  5   	   I)clr-namespace:BITServices.UI.UserControlsBITServices.UI.UserControls  5   	   0    *BITServices.UI.Windows.NewContractorWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:BITServices.UI.Windows     5   	   8uc)clr-namespace:BITServices.UI.UserControls     5   	     � Title$  New Contractor��5	   	   $	��725��6    $	��350��6-    � Icon$" ..\Images/Logo/LogoSmall.png��69    � 
ResizeMode$ NoResize=�6]   .��5
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
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $��* �6   .+�5"   
   �� $��Profile Picture:��6   $��0��6+   $��0��68   $��Right=�6H   $��Center=�6d   ,   &BITServices.UI.UserControls.ProfilePic  5#   
   -   5          Name$ ucProfilePic��5#      $��0��6.   $��1��6;   $��Right=�6K   $��0,0,5,5q�6�      ProfilePicImagePath 6g   �� *ContractorImagePath+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5$   
   $��First Name:��6   $��1��6&   $��0��63   $��Right=�6C   �� 5%   
   -   5        	 ��Name$	 txtFirstName��5%      $��1��6(   $��1��65      textboxPadding#��[  6E   ��6m   �� *NewContractor.FirstName+$ PropertyChanged=�$ TwoWay=�
 �� ValidatesOnExceptions
 . �� 5&   
   $��
Last Name:��6   $��2��6%   $��0��62   $��Right=�6B   �� 5'   
   -   5        $	 txtLastName��5'      $��2��6'   $��1��64   #��[  6D   ��6l   �� *NewContractor.LastName+$ PropertyChanged=�$ TwoWay=�
 . �� 5(   
   $��Street:��6   $��3��6"   $��0��6/   $��Right=�6?   �� 5)   
   -   5        $	 	txtStreet��5)      $��3��6%   $��1��62   #��[  6B   ��6j   �� *NewContractor.Street+$ PropertyChanged=�$ TwoWay=�
 . �� 5*   
   $��Suburb:��6   $��4��6"   $��0��6/   $��Right=�6?   �� 5+   
   -   5        $	 	txtSuburb��5+      $��4��6%   $��1��62   #��[  6B   ��6j   �� *NewContractor.Suburb+$ PropertyChanged=�$ TwoWay=�
 . �� 5,   
   $��State:��6   $��5��6!   $��0��6.   $��Right=�6>   �� 5-   
   -   5         ��Name$ cmbState��5-      $��5��6%   $��1��62   $	��0,5q�6B   $��23��6O    �� SelectedValuePath$ Content��6�    �� SelectedValue 6[   �� *NewContractor.State+$ PropertyChanged=�$ TwoWay=�
 . .@�5.      �� $	��NSW��6   �� 5/      $	��QLD��6   �� 50      $��NT��6   �� 51      $��WA��6   �� 52      $��SA��6   �� 53      $	��VIC��6   �� 54      $	��TAS��6   �� 55      $	��ACT��6   56      �� 57   
   $��
Post Code:��6   $��6��6%   $��0��62   $��Right=�6B   �� 58   
   -   5        $	 txtPostCode��58      $��6��6'   $��1��64   #��[  6D   ��6l   �� *NewContractor.PostCode+$ PropertyChanged=�$ TwoWay=�
 . �� 59   
   $��Email:��6   $��7��6!   $��0��6.   $��Right=�6>   �� 5:   
   -   5        $	 txtEmail��5:      $��7��6$   $��1��61   #��[  6A   ��6i   �� *NewContractor.Email+$ PropertyChanged=�$ TwoWay=�
 . �� 5;   
   $��Phone Number:��6   $��8��6(   $��0��65   $��Right=�6E   �� 5<   
   -	   5        $	 txtPhone��5<      $��8��6$   $��1��61   #��[  6A   ��6i   �� *NewContractor.PhoneNumber+$ PropertyChanged=�$ TwoWay=�
 . �� 5=   
   $��Mobile Number:��6   $��9��6)   $��0��66   $��Right=�6F   �� 5>   
   -
   5        $	 	txtMobile��5>      $��9��6%   $��1��62   #��[  6B   ��6j   �� *NewContractor.MobileNumber+$ PropertyChanged=�$ TwoWay=�
 . �� 5?   
   $��	Username:��6   $��10��6$   $��0��62   $��Right=�6B   �� 5@   
   -   5        $	 txtUsername��5@      $��10��6'   $��1��65   #��[  6E   ��6m   �� *NewContractor.Username+$ PropertyChanged=�$ TwoWay=�
 . �� 5A   
   $��	Password:��6   $��11��6$   $��0��62   $��Right=�6B   G� 5B   
   -   5         G�Name$ pswPassword��5B      $��11��6+   $��1��69   $	��0,5q�6J   $��23��6W   6c   �� 5C   
   $��Password Check:��6   $��12��6*   $��0��68   $��Right=�6H   G� 5D   
   -   5        $ pswCheck��5D      $��12��6(   $��1��66   $	��0,5q�6G   $��23��6T   6`   �� 5E   
   $��Skills:��6   $��13��6"   $��0��60   $��Right=�6@   �� 5F   
   -   5         ��Name$ 	stkSkills��5F      $��13��6(   $��1��66   .+�5G      �� -   5         ��Name$ 	lstSkills��5G      $	��100��6)   ��66   �� *NewContractor.SkillList+$ PropertyChanged=�$ TwoWay=��� 5H      -   5         ��Name$ btnAddSkill��5H      $��
Add Skills��6*   6?   5I      � 5J   
   -   5         �Name$ 	popSkills��5J      $��Mouse=�6#    � 	StaysOpen .  $��Slide=�6G    � AllowsTransparency . .��5K      � 
�������.+�5L      �� $	��200��6   $��Avaliable Skills��5M   H   .��5N      �� .+�5O      �� -   5        $��cmbSkillList��5O   #   $��23��67   ��6C   �� *	SkillList+ �� SelectedItem 6e   �� *SelectedSkill+$ PropertyChanged=�$ TwoWay=��� 5P      -   5        $ btnSkillAdd��5P   !   $	��Add��66   $��Right=�6D   $��5q�6`   $��0,5,0,0q�6l   ��6}   �� *AddSkillCommand+5Q      5R      5S      5T      �� 5U   
   $��Roster:��6   $��14��6"   $��0��60   $��Right=�6@   �� 5V   
   -   5        $ btnViewRoster��5V      $��14��6(   $��1��66   $��View Roster��6F   $	��0,5q�6\   6i   � 5X   
   $��Bottom=�6   $��Right=�6,   $��1��6H   $��15��6X   $��0,10,0,0q�6f   .+�5Y      �� -   5        $ 	btnCreate��5Y      $��Create Contractor��6(   $��5q�6D   $��0,0,5,0q�6P   ��6a   �� *NewContractorButtonCommand+�� 5Z      -   5        $ 	btnCancel��5Z      $��Cancel��6(   $��5q�69   6E   5[      5\      5]      