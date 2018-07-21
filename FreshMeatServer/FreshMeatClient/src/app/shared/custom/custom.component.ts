import { Component, ViewChild, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog, MatSnackBar } from '@angular/material';
import { DialogComponent, DialogModel } from './dialog/dialog.component';
import { Definition, FormService, CutomTableModel, BaseData } from './models';
import { FormGroup } from '@angular/forms';
import { DynamicFormService } from "@ng-dynamic-forms/core";
import swal from 'sweetalert2';
import { isNullOrUndefined } from 'util';


@Component({
  selector: 'custom-table',
  templateUrl: './custom.component.html',
  styleUrls: ['./custom.component.css']
})
export class CustomComponent<T extends BaseData> implements OnInit {
  @Input()
  TableModel: CutomTableModel<T>;

  @Output()
  onView: EventEmitter<T> = new EventEmitter<T>();

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;


  public displayedColumns: string[];
  public keys: string[];
  public ds: T[];
  public actionDefinition: Definition;
  public dataSource: MatTableDataSource<T>;
  public formService: FormService<T>;
  public inTrafic: boolean = false;
  public filter: string;
  public canEdit: boolean = true;
  public canAdd: boolean = true;
  public canRemove: boolean = true;
  public canView: boolean = true;
  public canFilter: boolean = true;
  constructor(public dialog: MatDialog, private dynamicFormService: DynamicFormService, public snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.configControls();
    this.inTrafic = true;
    this.TableModel.LoadAll().then((data) => {
      this.ds = data;
      this.configureColumn();
      this.dataSource = new MatTableDataSource(this.ds);
      this.formService = this.TableModel.FormService;
      this.configurePaginator();
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.inTrafic = false;
    }).catch((error) => {
      this.inTrafic = false;
      swal({
        type: 'warning',
        title: 'Advertencia',
        text: error,
        buttonsStyling: false,
        confirmButtonClass: 'btn btn-danger'
      }).catch(swal.noop);
    });
  }

  configurePaginator(): void {
    this.paginator._intl.itemsPerPageLabel = "Filas por página";
    this.paginator._intl.nextPageLabel = "Siguiente";
    this.paginator._intl.previousPageLabel = "Anterior";
    this.paginator._intl.getRangeLabel = (page: number, pageSize: number, length: number) => {
      if (length == 0 || pageSize == 0) {
        return `0 de ${length}`;
      }
      length = Math.max(length, 0);
      const startIndex = page * pageSize;
      const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
      return `Del ${startIndex + 1} al ${endIndex} de ${length}`;
    };
  }
  private configureColumn() {
    this.actionDefinition = JSON.parse(`{"${this.TableModel.InterfaceConfig.actionDefinitionKey}": "${this.TableModel.InterfaceConfig.ActionText}"}`);
    console.log(Object.keys(this.TableModel.InterfaceConfig.definition));
    this.keys = Object.keys(this.TableModel.InterfaceConfig.definition);
    this.displayedColumns = Object.keys(this.TableModel.InterfaceConfig.definition);
    this.displayedColumns.push(Object.keys(this.actionDefinition)[0]);
    console.log(this.displayedColumns);
  }
  configControls(){
    this.canAdd = this.TableModel.InterfaceConfig.CanAdd !== undefined ? this.TableModel.InterfaceConfig.CanAdd : this.canAdd;
    this.canEdit = this.TableModel.InterfaceConfig.CanEdit !== undefined ? this.TableModel.InterfaceConfig.CanEdit : this.canEdit;
    this.canRemove = this.TableModel.InterfaceConfig.CanRemove !== undefined ? this.TableModel.InterfaceConfig.CanRemove : this.canRemove;
    this.canView = this.TableModel.InterfaceConfig.CanView !== undefined ? this.TableModel.InterfaceConfig.CanView : this.canView;
    this.canFilter = this.TableModel.InterfaceConfig.CanFilter !== undefined ? this.TableModel.InterfaceConfig.CanFilter : this.canFilter;
  }
  public applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }

  openEditDialog(name: string, formData: T): void {
    let model = this.formService.GetModifyForm(formData);
    let indexData = this.ds.indexOf(formData);
    this.openDialog({
      title: name,
      formModel: model,
      formGroup: new FormGroup({}),
      index: indexData,
      ContextFormService: this.formService
    } as DialogModel)
      .then((result: DialogModel) => {
        let data = result.formGroup.value.data as T;
        this.inTrafic = true;
        this.TableModel.Edit(this.compareAndAsign(formData, data)).then((data: T) => {
          this.TableModel.Load(data).then((newData)=>{
            data = newData;
            this.editData(data, result.index);
            this.dataSource.filter = '';
            this.inTrafic = false;
            this.openSnackBar('Registro modificado', 'Ok');
          }).catch((error)=>{
            this.inTrafic = false;
            swal({
              type: 'warning',
              title: 'Advertencia',
              text: error,
              buttonsStyling: false,
              confirmButtonClass: 'btn btn-danger'
            }).catch(swal.noop);
          });
        }).catch((error) => {
          this.inTrafic = false;
          swal({
            type: 'warning',
            title: 'Advertencia',
            text: error,
            buttonsStyling: false,
            confirmButtonClass: 'btn btn-danger'
          }).catch(swal.noop);
        });
      })
      .catch((error) => {
        console.log(error);
      });
  }

  openAddDialog(title: string): void {
    let model = this.formService.GetAddForm();
    this.openDialog({
      title: title,
      formModel: model,
      formGroup: new FormGroup({}),
      index: this.ds.length + 1,
      ContextFormService: this.formService
    } as DialogModel)
      .then((result: DialogModel) => {
        let data = result.formGroup.value.data as T;
        this.inTrafic = true;
        this.TableModel.Add(data).then((result: T) => {
          this.addData(result);
          this.dataSource.filter = '';
          this.inTrafic = false;
          this.openSnackBar('Nuevo registro Agregado', 'Ok');
        }).catch((error) => {
          this.inTrafic = false;
          swal({
            type: 'warning',
            title: 'Advertencia',
            text: error,
            buttonsStyling: false,
            confirmButtonClass: 'btn btn-danger'
          }).catch(swal.noop);
        });
      })
      .catch((error) => {
        console.log(error);
      });
  }

  openDialog(dialogModel: DialogModel): Promise<DialogModel> {
    let dialogRef = this.dialog.open(DialogComponent, {
      width: this.TableModel.InterfaceConfig.DialogWidth ||'250px',
      data: dialogModel
    });
    let retProm: Promise<DialogModel> = new Promise<DialogModel>((resolve, reject) => {
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          let resultData: DialogModel = result as DialogModel;
          if (resultData.formGroup.valid) {
            resolve(resultData);
            console.log(result);
            console.log('The dialog was closed');
          }
          else {
            reject(resultData.formGroup.errors)
          }
        }
        else {
          reject("No data has come");
        }
      });
    });
    return retProm;
  }

  viewData(data: T){
    this.onView.emit(data);
  }
  editData(editData: T, editIndex: number) {
    let elementKeys = Object.keys(editData);
    for (let myKey = 0; myKey < elementKeys.length; myKey++) {
      this.ds[editIndex][elementKeys[myKey]] = editData[elementKeys[myKey]];
    }
  }

  addData(dataAdd: T) {
    this.ds.push(dataAdd);
  }

  deleteData(dataDel: T) {
    let self = this;
    swal({
      title: 'Eliminacion de registro',
      text: '¿Seguro que desea eliminar el registro seleccionado?',
      type: 'warning',
      showCancelButton: true,
      confirmButtonClass: 'btn btn-success',
      cancelButtonClass: 'btn btn-danger',
      confirmButtonText: 'Si, Lo deseo!',
      cancelButtonText: 'Cancelar!',
      buttonsStyling: false
    }).then(function () {
      let delIndex = self.ds.indexOf(dataDel);
      if (delIndex > -1) {
        self.inTrafic = true;
        self.TableModel.Delete(dataDel).then((data: T) => {
          self.ds.splice(delIndex, 1);
          self.dataSource.filter = '';
          self.inTrafic = false;
        }).catch((error) => {
          this.inTrafic = false;
          swal({
            type: 'warning',
            title: 'Advertencia',
            text: error,
            buttonsStyling: false,
            confirmButtonClass: 'btn btn-danger'
          }).catch(swal.noop);
        });
        self.ds.splice(delIndex, 1);
        self.dataSource.filter = '';
        swal({
          title: 'Eliminado!',
          text: 'El registro seleccionado fue eliminado.',
          type: 'success',
          confirmButtonClass: 'btn btn-success',
          buttonsStyling: false
        });
      }
    }).catch(swal.noop);
  }

  compareAndAsign(before: T, after: T): T {
    let elementKeys = Object.keys(after);
    for (let myKey = 0; myKey < elementKeys.length; myKey++) {
      before[elementKeys[myKey]] = after[elementKeys[myKey]];
    }
    return before;
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 2000,
    });
  }

  byLiteral(o: object, s: string) {
    s = s.replace(/\[(\w+)\]/g, '.$1'); // convert indexes to properties
    s = s.replace(/^\./, '');           // strip a leading dot
    let a = s.split('.');
    for (let i = 0, n = a.length; i < n; ++i) {
      let k = a[i];
      if (k in o) {
        o = o[k];
      } else {
        return;
      }
    }
    if (this.isEnum(o)) {
      o = this.getMetaLabel(o, s);
    }
    return o;
  }

  isEnum(instance: Object): boolean {
    let keys = Object.keys(instance);
    let values = [];
    for (let key of keys) {
      let value = instance[key];

      if (typeof value === 'number') {
        value = value.toString();
      }
      values.push(value);
    }
    for (let key of keys) {
      if (values.indexOf(key) < 0) {
        return false;
      }
    }
    return true;
  }

  getMetaLabel(prop: Object, metaKey: string): Object{    
    if(this.TableModel.InterfaceConfig.MetaLabels){
      prop = isNullOrUndefined(this.TableModel.InterfaceConfig.MetaLabels[metaKey]) ? 
        prop : this.TableModel.InterfaceConfig.MetaLabels[metaKey][prop as number]
    }
    return prop
  }
}
