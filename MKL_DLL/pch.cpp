// pch.cpp: файл исходного кода, соответствующий предварительно скомпилированному заголовочному файлу

#include "pch.h"
#include "cmath"
#include "mkl.h" 
#include <chrono>

// При использовании предварительно скомпилированных заголовочных файлов необходим следующий файл исходного кода для выполнения сборки.

class Timer
{
private:
	using clock_t = std::chrono::high_resolution_clock;
	using second_t = std::chrono::duration<double, std::ratio<1> >;

	std::chrono::time_point<clock_t> m_beg;

public:
	Timer() : m_beg(clock_t::now())
	{
	}

	void reset()
	{
		m_beg = clock_t::now();
	}

	double elapsed() const
	{
		return std::chrono::duration_cast<second_t>(clock_t::now() - m_beg).count();
	}
};

double double_exp_time(const int n, const double* a)
{
	double* y = new double[n];

	Timer t;

	for (int i = 0; i < n; i++)
	{
		y[i] = exp(a[i]);
	}

	return t.elapsed();
}

double float_exp_time(const int n, const float* a)
{
	float* y = new float[n];

	Timer t;

	for (int i = 0; i < n; i++)
	{
		y[i] = exp(a[i]);
	}

	return t.elapsed();
}

extern "C" _declspec(dllexport)
void __cdecl MKL_vmdExp(int n, double* a, double& time_1, double& time_2, double& time_3, 
	double& res_1, double& res_2, double& point)
{
	double work_time = double_exp_time(n, a);

	double* y_vml_ha = new double[n];
	double* y_vml_ep = new double[n];

	vmdExp(n, a, y_vml_ha, VML_HA);

	Timer t;

	vmdExp(n, a, y_vml_ha, VML_HA);

	double time_vml_ha = t.elapsed();

	t.reset();

	vmdExp(n, a, y_vml_ep, VML_EP);

	double time_vml_ep = t.elapsed();

	double y_vml_ha_val = y_vml_ha[0];
	double y_vml_ep_val = y_vml_ep[0];
	double max_dif = abs(y_vml_ep[0] - y_vml_ha[0]) / abs(y_vml_ha[0]);
	double max_dif_point = a[0];
	for (int i = 1; i < n; i++)
	{
		double curr_dif = abs(y_vml_ep[i] - y_vml_ha[i]) / abs(y_vml_ha[i]);
		if (curr_dif > max_dif)
		{
			max_dif = curr_dif;
			max_dif_point = a[i];
			y_vml_ha_val = y_vml_ha[i];
			y_vml_ep_val = y_vml_ep[i];
		}
	}

	time_1 = time_vml_ha;
	time_2 = time_vml_ep;
	time_3 = work_time;
	res_1 = y_vml_ha_val;
	res_2 = y_vml_ep_val;
	point = max_dif_point;
}

extern "C" _declspec(dllexport)
void __cdecl MKL_vmsExp(int n, float* a, double& time_1, double& time_2, double& time_3,
	double& res_1, double& res_2, double& point)
{
	double work_time = float_exp_time(n, a);

	float* y_vml_ha = new float[n];
	float* y_vml_ep = new float[n];

	vmsExp(n, a, y_vml_ha, VML_HA);

	Timer t;

	vmsExp(n, a, y_vml_ha, VML_HA);

	double time_vml_ha = t.elapsed();

	t.reset();

	vmsExp(n, a, y_vml_ep, VML_EP);

	double time_vml_ep = t.elapsed();

	double y_vml_ha_val = y_vml_ha[0];
	double y_vml_ep_val = y_vml_ep[0];
	double max_dif = abs(y_vml_ep[0] - y_vml_ha[0]) / abs(y_vml_ha[0]);
	double max_dif_point = a[0];
	for (int i = 1; i < n; i++)
	{
		double curr_dif = abs(y_vml_ep[i] - y_vml_ha[i]) / abs(y_vml_ha[i]);
		if (curr_dif > max_dif)
		{
			max_dif = curr_dif;
			max_dif_point = a[i];
			y_vml_ha_val = y_vml_ha[i];
			y_vml_ep_val = y_vml_ep[i];
		}
	}

	time_1 = time_vml_ha;
	time_2 = time_vml_ep;
	time_3 = work_time;
	res_1 = y_vml_ha_val;
	res_2 = y_vml_ep_val;
	point = max_dif_point;
}

double double_erf_time(const int n, const double* a)
{
	double* y = new double[n];

	Timer t;

	for (int i = 0; i < n; i++)
	{
		y[i] = erf(a[i]);
	}

	return t.elapsed();
}

double float_erf_time(const int n, const float* a)
{
	float *y = new float[n];

	Timer t;

	for (int i = 0; i < n; i++)
	{
		y[i] = erf(a[i]);
	}

	return t.elapsed();
}

extern "C" _declspec(dllexport)
void __cdecl MKL_vmdErf(int n, double* a, double& time_1, double& time_2, double& time_3, 
	double& res_1, double& res_2, double& point)
{
	double work_time = double_erf_time(n, a);

	double* y_vml_ha = new double[n];
	double* y_vml_ep = new double[n];

	vmdErf(n, a, y_vml_ha, VML_HA);

	Timer t;

	vmdErf(n, a, y_vml_ha, VML_HA);

	double time_vml_ha = t.elapsed();

	t.reset();

	vmdErf(n, a, y_vml_ep, VML_EP);

	double time_vml_ep = t.elapsed();

	double y_vml_ha_val = y_vml_ha[0];
	double y_vml_ep_val = y_vml_ep[0];
	double max_dif = abs(y_vml_ep[0] - y_vml_ha[0]) / abs(y_vml_ha[0]);
	double max_dif_point = a[0];
	for (int i = 1; i < n; i++)
	{
		double curr_dif = abs(y_vml_ep[i] - y_vml_ha[i]) / abs(y_vml_ha[i]);
		if (curr_dif > max_dif)
		{
			max_dif = curr_dif;
			max_dif_point = a[i];
			y_vml_ha_val = y_vml_ha[i];
			y_vml_ep_val = y_vml_ep[i];
		}
	}

	time_1 = time_vml_ha;
	time_2 = time_vml_ep;
	time_3 = work_time;
	res_1 = y_vml_ha_val;
	res_2 = y_vml_ep_val;
	point = max_dif_point;
}

extern "C" _declspec(dllexport)
void __cdecl MKL_vmsErf(int n, float* a, double& time_1, double& time_2, double& time_3,
	double& res_1, double& res_2, double& point)
{
	double work_time = float_erf_time(n, a);

	float* y_vml_ha = new float[n];
	float* y_vml_ep = new float[n];

	vmsErf(n, a, y_vml_ha, VML_HA);

	Timer t;

	vmsErf(n, a, y_vml_ha, VML_HA);

	double time_vml_ha = t.elapsed();

	t.reset();

	vmsErf(n, a, y_vml_ep, VML_EP);

	double time_vml_ep = t.elapsed();

	double y_vml_ha_val = y_vml_ha[0];
	double y_vml_ep_val = y_vml_ep[0];
	double max_dif = abs(y_vml_ep[0] - y_vml_ha[0]) / abs(y_vml_ha[0]);
	double max_dif_point = a[0];
	for (int i = 1; i < n; i++)
	{
		double curr_dif = abs(y_vml_ep[i] - y_vml_ha[i]) / abs(y_vml_ha[i]);
		if (curr_dif > max_dif)
		{
			max_dif = curr_dif;
			max_dif_point = a[i];
			y_vml_ha_val = y_vml_ha[i];
			y_vml_ep_val = y_vml_ep[i];
		}
	}

	time_1 = time_vml_ha;
	time_2 = time_vml_ep;
	time_3 = work_time;
	res_1 = y_vml_ha_val;
	res_2 = y_vml_ep_val;
	point = max_dif_point;
}