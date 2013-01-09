//
//  MasterViewController.h
//  try2
//
//  Created by John Featherly on 1/8/13.
//  Copyright (c) 2013 John Featherly. All rights reserved.
//

#import <UIKit/UIKit.h>

@class DetailViewController;

@interface MasterViewController : UITableViewController

@property (strong, nonatomic) DetailViewController *detailViewController;

@end
