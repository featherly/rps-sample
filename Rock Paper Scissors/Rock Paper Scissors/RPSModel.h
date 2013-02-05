//
//  RPSModel.h
//  Rock Paper Scissors
//
//  Created by Corey Featherly on 1/8/13.
//  Copyright (c) 2013 myself. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface RPSModel : NSObject

@property (nonatomic) NSInteger lifetimeWins;
@property (nonatomic) NSInteger lifetimeLoses;
@property (nonatomic) NSInteger lifetimeTies;
@property (nonatomic) NSMutableArray* history;
@property (nonatomic) NSInteger enemySelection;

-(NSString*)roundResult1P:(NSInteger)playerSelection;

@end
