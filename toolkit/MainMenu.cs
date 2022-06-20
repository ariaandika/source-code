using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

namespace Toolkit
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Edit the mixer exposed value string")]
        public AudioMixer audioMixer;
        public TMP_Dropdown resolutionDropdown;

        Resolution[] _resolutions;

        void Awake()
        {
            _resolutions = Screen.resolutions;
            resolutionDropdown.ClearOptions();
            var options = new List<string>();
            var currentRes = 0;
            for (var i = 0; i < _resolutions.Length; i++)
            {
                options.Add($" {_resolutions[i].width} x {_resolutions[i].height}");
                if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
                    currentRes = i;
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentRes;
            resolutionDropdown.RefreshShownValue();
        }

        /// <summary>
        /// value from -80 to 0
        /// </summary>
        public void SetVolume(float volume) => audioMixer.SetFloat("MasterVolume", volume);
        public void SetQuality(int qualityIndex) => QualitySettings.SetQualityLevel(qualityIndex);
        public void SetFullscreen(bool isFullscreen) => Screen.fullScreen = isFullscreen;
        public void SetResolution(int resolutionIndex)
        {
            var r = _resolutions[resolutionIndex];
            Screen.SetResolution(r.width, r.height, Screen.fullScreen);
        }
    }
}