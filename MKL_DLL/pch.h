// pch.h: это предварительно скомпилированный заголовочный файл.
// Перечисленные ниже файлы компилируются только один раз, что ускоряет последующие сборки.
// Это также влияет на работу IntelliSense, включая многие функции просмотра и завершения кода.
// Однако изменение любого из приведенных здесь файлов между операциями сборки приведет к повторной компиляции всех(!) этих файлов.
// Не добавляйте сюда файлы, которые планируете часто изменять, так как в этом случае выигрыша в производительности не будет.

#ifndef PCH_H
#define PCH_H

// Добавьте сюда заголовочные файлы для предварительной компиляции
#include "framework.h"

extern "C" _declspec(dllexport)
void __cdecl MKL_vmdExp(int n, double* a, double& time_1, double& time_2, double& time_3, 
	double& res_1, double& res_2, double& point);

extern "C" _declspec(dllexport)
void __cdecl MKL_vmsExp(int n, float* a, double& time_1, double& time_2, double& time_3,
	double& res_1, double& res_2, double& point);

extern "C" _declspec(dllexport)
void __cdecl MKL_vmsErf(int n, float* a, double& time_1, double& time_2, double& time_3,
	double& res_1, double& res_2, double& point);

extern "C" _declspec(dllexport)
void __cdecl MKL_vmdErf(int n, double* a, double& time_1, double& time_2, double& time_3,
	double& res_1, double& res_2, double& point);

double double_exp_time(const int n, const double* a);

double float_exp_time(const int n, const float* a);

double double_erf_time(const int n, const double* a);

double float_erf_time(const int n, const float* a);


#endif //PCH_H
