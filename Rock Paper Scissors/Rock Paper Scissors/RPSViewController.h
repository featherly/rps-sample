//
//  RPSViewController.h
//  Rock Paper Scissors
//
//  Created by Corey Featherly on 1/7/13.
//  Copyright (c) 2013 myself. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface RPSViewController : UIViewController
@property (weak, nonatomic) IBOutlet UISegmentedControl *selector;
@property (weak, nonatomic) IBOutlet UIImageView *imgOutcome;
@property (weak, nonatomic) IBOutlet UIImageView *imgPlayer;
@property (weak, nonatomic) IBOutlet UIImageView *imgEnemy;
@property (weak, nonatomic) IBOutlet UILabel *lblOutcome;
@property (weak, nonatomic) IBOutlet UIButton *btnPlay;

@property (weak, nonatomic) IBOutlet UILabel *lblLifetimeWins;
@property (weak, nonatomic) IBOutlet UILabel *lblLifetimeTies;
@property (weak, nonatomic) IBOutlet UILabel *lblLifetimeLoses;

@end
