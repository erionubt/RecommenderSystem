/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { StudentHomeComponent } from './student-home.component';

let component: StudentHomeComponent;
let fixture: ComponentFixture<StudentHomeComponent>;

describe('StudentHome component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ StudentHomeComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(StudentHomeComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});