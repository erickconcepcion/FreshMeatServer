import { NgModule } from '@angular/core';

import { MenuItems } from './menu-items/menu-items';
import {CustomModule} from './custom/custom.module'
import { AccordionAnchorDirective, AccordionLinkDirective, AccordionDirective } from './accordion';


@NgModule({
  declarations: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective
  ],
  exports: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    CustomModule
   ],
  providers: [ MenuItems ]
})
export class SharedModule { }
