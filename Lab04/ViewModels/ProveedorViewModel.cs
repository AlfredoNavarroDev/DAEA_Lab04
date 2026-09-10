using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab04.Models;
using Lab04.Repositories;

namespace Lab04.ViewModels;

public partial class ProveedorViewModel : ObservableObject
{
    private readonly ProveedorRepository _repository;

    public ProveedorViewModel() : this(new ProveedorRepository()) { }

    public ProveedorViewModel(ProveedorRepository repository)
    {
        _repository = repository;
        Proveedores = new ObservableCollection<Proveedor>();
        Cargar();
    }

    public ObservableCollection<Proveedor> Proveedores { get; }

    [ObservableProperty]
    private Proveedor? proveedorSeleccionado;

    [ObservableProperty]
    private string? filtroNombreContacto;

    [ObservableProperty]
    private string? filtroCiudad;

    [RelayCommand]
    private void Cargar()
    {
        Proveedores.Clear();
        foreach (var proveedor in _repository.List())
        {
            Proveedores.Add(proveedor);
        }
    }

    [RelayCommand]
    private void Buscar()
    {
        Proveedores.Clear();
        foreach (var proveedor in _repository.BuscarPorContactoCiudad(FiltroNombreContacto, FiltroCiudad))
        {
            Proveedores.Add(proveedor);
        }
    }

    [RelayCommand]
    private void Nuevo()
    {
        var nuevo = new Proveedor();
        Proveedores.Add(nuevo);
        ProveedorSeleccionado = nuevo;
    }

    [RelayCommand]
    private void Guardar()
    {
        if (ProveedorSeleccionado is null) return;

        if (ProveedorSeleccionado.ProveedorID == 0)
        {
            ProveedorSeleccionado.ProveedorID = _repository.Insert(ProveedorSeleccionado);
        }
        else
        {
            _repository.Update(ProveedorSeleccionado);
        }
        Cargar();
    }

    [RelayCommand]
    private void Eliminar()
    {
        if (ProveedorSeleccionado is null || ProveedorSeleccionado.ProveedorID == 0) return;
        _repository.Delete(ProveedorSeleccionado.ProveedorID);
        Cargar();
    }
}
