import { DynamicFormService, DynamicFormControlModel } from "@ng-dynamic-forms/core";
import { Observable } from "rxjs";

export interface FormService<T> {
    GetAddForm(): DynamicFormControlModel[];
    GetModifyForm(data: T): DynamicFormControlModel[];
    // tslint:disable-next-line:member-ordering
    OnMatEvent?: (event: any, models: DynamicFormControlModel[]) => void;
}
export interface BaseSecureHttpService<T> {
    GetAll(): Promise<T[]>;
    Get(data: T): Promise<T>;
    Post(data: T): Promise<T>;
    Put(data: T): Promise<number>;
    Delete(data: T): Promise<number>;
}
export interface BaseData {
    id: number;
}
export interface Definition {
    [key: string]: string;
}
export interface MetaLabels {
    [key: string]: string[];
}
export interface InterfaceConfig {
    EditTitle: string;
    AddTitle: string;
    ActionText: string;
    definition: Definition;
    actionDefinitionKey: string;
    DialogWidth?: string;
    CanEdit?: boolean;
    CanAdd?: boolean;
    CanRemove?: boolean;
    CanView?: boolean;
    CanFilter?: boolean;
    MetaLabels?: MetaLabels;
}
export interface CutomTableModel<T>{
    InterfaceConfig: InterfaceConfig;
    FormService: FormService<T>;
    LoadAll: () => Promise<T[]>;
    Load: (data: T) => Promise<T>;
    Add: (data: T) => Promise<T>;
    Edit: (data: T) => Promise<T>;
    Delete: (data: T) => Promise<T>;
    DetailLink?: string;
    DetailSearch?: Observable<string>;
}