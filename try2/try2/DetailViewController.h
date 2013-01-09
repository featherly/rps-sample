//
//  DetailViewController.h
//  try2
//
//  Created by John Featherly on 1/8/13.
//  Copyright (c) 2013 John Featherly. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface DetailViewController : UIViewController <UISplitViewControllerDelegate>

@property (strong, nonatomic) id detailItem;

@property (weak, nonatomic) IBOutlet UILabel *detailDescriptionLabel;
@end
