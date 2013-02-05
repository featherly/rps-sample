//
//  RPSViewController.m
//  Rock Paper Scissors
//
//  Created by Corey Featherly on 1/7/13.
//  Copyright (c) 2013 myself. All rights reserved.
//

#import "RPSViewController.h"
#import "RPSModel.h"

static int selectionRock = 0;
static int selectionPaper = 1;
static int selectionScissors = 2;

@interface RPSViewController ()

@property (nonatomic) RPSModel *model;

@end


@implementation RPSViewController

@synthesize model = _model;
@synthesize lblOutcome = _lblOutcome;

-(RPSModel*)model{
    if(!_model)
        _model = [[RPSModel alloc] init];
    return _model;
}

- (IBAction)play {
    NSLog(@"Play button pressed");
    self.btnPlay.enabled = NO;
    //0=rock   1=paper   2=scissors
    NSInteger playerSelection = [[self selector] selectedSegmentIndex];
    NSLog(@"Player Selection: %d",playerSelection);
    if(playerSelection > -1){
        // NSInteger randNumber = rand() % (max-min+1)+min
        NSString *roundResult = [self.model roundResult1P:playerSelection];
        NSInteger enemySelection = self.model.enemySelection;
        
        if(enemySelection==selectionRock)
            self.imgEnemy.image = [UIImage imageNamed:@"roc.png"];
        else if (enemySelection==selectionScissors)
            self.imgEnemy.image = [UIImage imageNamed:@"sci.png"];
        else if (enemySelection==selectionPaper)
            self.imgEnemy.image = [UIImage imageNamed:@"pap.png"];
        
        if([roundResult isEqualToString:@"win"])
            [self playerWins];
        else if([roundResult isEqualToString:@"loss"])
            [self playerLoses];
        else if([roundResult isEqualToString:@"tie"])
            [self tie];
        
    }
}


-(void)playerWins{
    self.imgOutcome.image = [UIImage imageNamed:@"win.png"];
    NSLog(@"Player wins!");
    self.selector.selectedSegmentIndex = -1;
    self.lblOutcome.text = @"VICTORY!";
    self.lblLifetimeWins.text = [NSString stringWithFormat:@"%d",[self.model lifetimeWins]];
}

-(void)playerLoses{
    self.imgOutcome.image = [UIImage imageNamed:@"fail.png"];
    NSLog(@"Player Looses!");
    self.selector.selectedSegmentIndex = -1;
    self.lblOutcome.text = @"DEFEAT!";
    self.lblLifetimeLoses.text = [NSString stringWithFormat:@"%d",[self.model lifetimeLoses]];
}

-(void)tie{
    self.imgOutcome.image = [UIImage imageNamed:@"tie.png"];
    NSLog(@"Player ties!");
    self.selector.selectedSegmentIndex = -1;
    self.lblOutcome.text = @"TIE!";
    self.lblLifetimeTies.text = [NSString stringWithFormat:@"%d",[self.model lifetimeTies]];
    //self.history.text = [self.history.text stringByAppendingString:[NSString stringWithFormat:@" tie(%@)", selection]];
}
- (IBAction)selectionChanged {
    self.btnPlay.enabled = YES;
    self.imgEnemy.image = nil;
    self.imgOutcome.image = nil;
    self.lblOutcome.text = @"";
    
    NSInteger playerSelection = [[self selector] selectedSegmentIndex];
    if(playerSelection==selectionRock)
        self.imgPlayer.image = [UIImage imageNamed:@"roc.png"];
    else if (playerSelection==selectionScissors)
        self.imgPlayer.image = [UIImage imageNamed:@"sci.png"];
    else if (playerSelection==selectionPaper)
        self.imgPlayer.image = [UIImage imageNamed:@"pap.png"];
}

-(void)viewWillAppear:(BOOL)animated{
    self.btnPlay.enabled = NO;
    self.selector.selectedSegmentIndex = -1;
    self.imgEnemy.image = nil;
    self.imgOutcome.image = nil;
    self.imgPlayer.image = nil;
    self.lblOutcome.text = @"";
}

@end
